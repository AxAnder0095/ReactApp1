import { createBrowserRouter } from "react-router-dom"; 
import App from "./App.jsx";
import { Home } from "./pages/Home.jsx"
import { AddTransaction } from "./pages/AddTransaction.jsx"
import { DeleteTransaction } from "./pages/DeleteTransaction.jsx"


export const router = createBrowserRouter([
    { path: "/", element: <App /> },
    { path: "/home", element: <Home /> },
    { path: "/add", element: <AddTransaction /> },
    { path: "/delete", element: <DeleteTransaction/> },

])