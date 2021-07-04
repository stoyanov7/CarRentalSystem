import { LinkContainer } from 'react-router-bootstrap'
import { useSelector, useDispatch } from 'react-redux';
import { logoutUser } from '../redux/actions/userActions';

import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';

const Navigation = () => {
   const { authenticated } = useSelector(state => state.user);
   let dispatch = useDispatch();

   const handleLogout = () => dispatch(logoutUser());

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
            {
               authenticated ? (
                  <>
                     <Nav.Link>Create car</Nav.Link>
                     <Nav.Link>My cars</Nav.Link>
                     <Nav.Link>Profile</Nav.Link>
                     <Nav.Link onClick={handleLogout}>Logout</Nav.Link>
                  </>
               ) : (
                  <LinkContainer to="/login">
                     <Nav.Link>Login</Nav.Link>
                  </LinkContainer>     
               )
            }                
         </Nav>
      </Navbar>
   )
}

export default Navigation