import { LinkContainer } from 'react-router-bootstrap'

import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';

export default function Navigation() {
   return (
      <Navbar bg="dark" variant="dark">
         <LinkContainer to="/">
            <Navbar.Brand>Car Rental System</Navbar.Brand>
         </LinkContainer>         
         <Nav className="mr-auto">
            <LinkContainer to="/">
               <Nav.Link>Home</Nav.Link>
            </LinkContainer>
            <LinkContainer to="/cars">
               <Nav.Link>Cars</Nav.Link>
            </LinkContainer>
            <LinkContainer to="/login">
               <Nav.Link>Login</Nav.Link>
            </LinkContainer>          
         </Nav>
      </Navbar>
   )
}