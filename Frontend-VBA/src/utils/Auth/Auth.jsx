export const SetUser = (user) => {
	user = JSON.stringify(user);
	localStorage.setItem('_vbaUser', user, {
	  expires: 1, /* expires in 1 day*/
	  path: '/',
	  secure: false,
	  sameSite: 'Strict'
	});
	return true;
  };
  
  // Function to get the User token from the Local Storage
  export const GetUser = () => {
	var user = localStorage.getItem('_vbaUser');
	return JSON.parse(user);
  };