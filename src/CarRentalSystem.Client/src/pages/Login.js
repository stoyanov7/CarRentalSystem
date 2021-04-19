import { Link } from 'react-router-dom';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

export default function Login() {
   return (
      <div className="container-fluid">
         <div className="row">
            <div className="col-lg-4"></div>
            <div className="col-lg-4">
               <Form>
                  <Form.Group controlId="email">
                     <Form.Label>Email address</Form.Label>
                     <Form.Control type="email" placeholder="Enter email" />
                     <Form.Text className="text-muted">
                        We'll never share your email with anyone else.
                     </Form.Text>
                  </Form.Group>
                  <Form.Group controlId="password">
                     <Form.Label>Password</Form.Label>
                     <Form.Control type="password" placeholder="Password" />
                  </Form.Group>
                  <Button variant="primary" type="submit">
                     Submit
                  </Button>
               </Form>
               <small>don't have an account? Sign up <Link to="/signup">here</Link></small>
            </div>
            <div className="col-lg-4"></div>
         </div>
      </div>
   )
}