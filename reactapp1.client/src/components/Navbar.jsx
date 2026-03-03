import { NavLink } from "react-router-dom";
import "../styles/Navbar.scss"

export const Navbar = () => {
    return (
        <header className="Navbar-Header">
            <nav className="Navbar">
                <div className="nav-brand">
                    <NavLink to="/" className="nav-logo">ReactApp</NavLink>
                </div>
                <div className="nav-links">
                    <NavLink to="/" className={ ({ isActive }) => isActive ? "link active" : "link" }>Home</NavLink>
                    <NavLink to="/add" className={ ({ isActive }) => isActive ? "link active" : "link" }>Add</NavLink>
                    <NavLink to="/update" className={ ({ isActive }) => isActive ? "link active" : "link" }>Update</NavLink>
                    <NavLink to="/delete" className={ ({ isActive }) => isActive ? "link active" : "link" }>Delete</NavLink>
                </div>
            </nav>
        </header>
    )
}