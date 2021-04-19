import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';

export default function Navigation() {
   return (
      <Navbar bg="dark" variant="dark">
         <Navbar.Brand href="#home">Car Rental System</Navbar.Brand>
         <Nav className="mr-auto">
            <Nav.Link href="#home">Home</Nav.Link>
            <Nav.Link href="#cars">Cars</Nav.Link>
            <Nav.Link href="#login">Login</Nav.Link>
         </Nav>
      </Navbar>
   )
}