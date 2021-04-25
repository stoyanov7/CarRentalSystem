import React, { useState, } from 'react';
import { useHistory } from "react-router-dom";
import { useDispatch } from 'react-redux';
import { signupUser } from '../redux/actions/userActions';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const Signup = () => {
   const [signUpData, setSignUpData] = useState({
      email: '',
      password: '',
      name: '',
      phoneNumber: ''
   });

   let history = useHistory();
   let dispatch = useDispatch();

   const handleSubmit = (event) => {
      event.preventDefault();

      dispatch(signupUser(signUpData, history));
   }

   const handleChange = (event) => {
      setSignUpData({
         ...signUpData,
         [event.target.name]: event.target.value
      })
   }   

   return (
      <div className="container-fluid">
         <div className="row">
            <div className="col-lg-4"></div>
            <div className="col-lg-4">
               <Form noValidate onSubmit={handleSubmit}>
                  <Form.Group controlId="email">
                     <Form.Label>Email address</Form.Label>
                     <Form.Control 
                        type="email" 
                        name="email" 
                        placeholder="Enter email" 
                        onChange={handleChange} 
                     />
                     <Form.Text className="text-muted">
                        We'll never share your email with anyone else.
                     </Form.Text>
                  </Form.Group>
                  <Form.Group controlId="password">
                     <Form.Label>Password</Form.Label>
                     <Form.Control 
                        type="password" 
                        name="password" 
                        placeholder="Password" 
                        onChange={handleChange} 
                     />
                  </Form.Group>
                  <Form.Group controlId="name">
                     <Form.Label>Name</Form.Label>
                     <Form.Control 
                        type="text" 
                        name="name" 
                        placeholder="Name" 
                        onChange={handleChange} 
                     />
                  </Form.Group>
                  <Form.Group controlId="phone">
                     <Form.Label>Phone</Form.Label>
                     <Form.Control
                        type="phone" 
                        name="phoneNumber" 
                        placeholder="Phone" 
                        onChange={handleChange} 
                     />
                  </Form.Group>
                  <Button variant="primary" type="submit">
                     Submit
                  </Button>
               </Form>
            </div>
            <div className="col-lg-4"></div>
         </div>
      </div>
   )
}

export default Signup