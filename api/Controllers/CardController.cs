using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.DTOs.CardDtos;
using Microsoft.AspNetCore.Identity;
using api.Models;
using api.Interfaces;
using api.Data;
using api.Extensions;
using Microsoft.AspNetCore.Authorization;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinmanager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CardController> _logger;
        private readonly ICardRepository _cardRepo;

        public CardController(
            UserManager<AppUser> userManager,
            ITokenService tokenService,
            SignInManager<AppUser> signinmanager,
            IEmailService emailService,
            ILogger<CardController> logger,
            IConfiguration configuration,
            ApplicationDBContext context,
            ICardRepository cardRepo)
        {
            _userManager = userManager;
            _signinmanager = signinmanager;
            _emailService = emailService;
            _logger = logger;
            _configuration = configuration;
            _context = context;
            _cardRepo = cardRepo;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardDto createCardDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //RETRIVE THE LOGGED IN USER 
                var userEmail = User.GetUserEmail();
                var user = await _userManager.FindByEmailAsync(userEmail);

                if (user == null)
                {
                    return Unauthorized("User not logged in.");
                }

                // To see whats happening see CardRepository "CreateCardAsync method"
                var createCard = await _cardRepo.CreateCardAsync(user.Id, createCardDto);

                if (createCard == null)
                {
                    return BadRequest("Failed to upload image. Please try again");
                }

                var recipient = User.GetUserEmail();
                var subject = "Card creation";
                var templateName = "CardCreate";

                await _emailService.SendEmailAsync(recipient, subject, user.Name, "", templateName);

                return Ok("Card created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating card.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            try
            {
                // Retrieve the card details by ID
                var cardDetails = await _context.CardDetails.FindAsync(id);
                if (cardDetails == null)
                {
                    return NotFound("Card details not found ");

                }

                // Retrieve the logged-in user
                var userEmail = User.GetUserEmail();
                var user = await _userManager.FindByEmailAsync(userEmail);

                if (user == null)
                {
                    return Unauthorized("User not logged in.");
                }

                // Ensure the card belongs to the logged-in user
                if (cardDetails.UserID != user.Id)
                {
                    return Forbid("you are not authorized to delete this card ");
                }

                //DELETING THE CARD 
                var deleteCard = await _cardRepo.DeleteCardAsync(user.Id, id); ;

                if (deleteCard == null)
                {
                    return BadRequest("Failed to delete card. Please try again");
                }

                var recipient = User.GetUserEmail();
                var subject = "Card Deletion";
                var templateName = "CardDeletion";

                await _emailService.SendEmailAsync(recipient, subject, user.Name, "CardDeletion", templateName);

                return Ok("Card deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting card.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}