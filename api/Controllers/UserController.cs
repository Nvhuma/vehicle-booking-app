using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.AccountDtos;
using api.Extensions;
using api.Interfaces;
using api.Mappers.UserMappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinmanager;
        private readonly IEmailService _emailService;
        private readonly ITitleCaseService _titleCaseService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CardController> _logger;
        private readonly ICardRepository _cardRepo;
        private readonly IUserRepository _userRepo;

        public UserController(
            UserManager<AppUser> userManager,
            ITitleCaseService titleCaseService,
            SignInManager<AppUser> signinmanager,
            IEmailService emailService,
            ILogger<CardController> logger,
            IConfiguration configuration,
            ApplicationDBContext context,
            ICardRepository cardRepo,
            IUserRepository userRepo)
        {
            _userManager = userManager;
            _signinmanager = signinmanager;
            _emailService = emailService;
            _logger = logger;
            _configuration = configuration;
            _titleCaseService = titleCaseService;
            _context = context;
            _cardRepo = cardRepo;
            _userRepo = userRepo;
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserDetails(string userId = null)
        {
            // Check if the current user is an admin
            if (User.IsInRole("Admin") && !string.IsNullOrEmpty(userId))
            {
                // Admin is fetching details for another user
                var user = await _userManager.FindByIdAsync(userId); // Await the result of FindByIdAsync
                if (user == null)
                {
                    return NotFound(); // Handle case where user is not found
                }

                var userDetails = await _userRepo.GetUserById(userId); 
                var userDetailsDto = userDetails.ToGetUserDto(); 

                return Ok(userDetailsDto); 
            }
            else
            {
                // Regular user fetching their own details
                var currentUserEmail = User.GetUserEmail();
                var user = await _userManager.FindByEmailAsync(currentUserEmail);
                if (user == null)
                {
                    return NotFound(); // Handle case where user is not found
                }

                var userDetails = await _userRepo.GetUserById(user.Id);
                var userDetailsDto = userDetails.ToGetUserDto();

                return Ok(userDetailsDto);
            }
        }

        [HttpPatch("Edit-user-details")]
        [Authorize]
        public async Task<IActionResult> EditUserDetails([FromBody] EditUserDetailsDto editUserDetailsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Getting the currently logged-in user
                var userEmail = User.GetUserEmail();
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    return Unauthorized("User not found");
                }

                // Apply updates only to fields that are provided (non-null)
                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.Name))
                {
                    user.Name = _titleCaseService.ToTitleCase(editUserDetailsDto.Name).Trim();
                }

                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.Surname))
                {
                    user.Surname = _titleCaseService.ToTitleCase(editUserDetailsDto.Surname).Trim();
                }

                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.UserName))
                {
                    user.UserName = editUserDetailsDto.UserName;
                }

                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.Email))
                {
                    user.Email = editUserDetailsDto.Email.ToLower();
                }

                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.PhoneNumber))
                {
                    user.PhoneNumber = editUserDetailsDto.PhoneNumber;
                }

                var updateUserResult = await _userManager.UpdateAsync(user);
                if (!updateUserResult.Succeeded)
                {
                    return BadRequest(new { errors = updateUserResult.Errors.Select(e => e.Description) });
                }

                return Ok("User details updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while editing user details.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}