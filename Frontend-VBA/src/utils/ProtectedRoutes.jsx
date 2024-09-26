import { Outlet, Navigate } from "react-router-dom";
import { GetUser } from "./Auth";

function ProtectedRoutes() {
	const user = GetUser();
	return user ? <Outlet/> : <Navigate to="/login"/>
}

export default ProtectedRoutes