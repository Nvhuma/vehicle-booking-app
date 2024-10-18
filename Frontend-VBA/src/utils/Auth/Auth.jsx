export const SetUser = (user) => {
  user = JSON.stringify(user);
  localStorage.setItem("_vbaUser", user); // No expiration or path options in localStorage
  return true;
};

// Function to get the User token from the Local Storage
export const GetUser = () => {
  var user = localStorage.getItem("_vbaUser");
  return JSON.parse(user);
};

export const RemoveUser = () => {
  localStorage.clear();
};
