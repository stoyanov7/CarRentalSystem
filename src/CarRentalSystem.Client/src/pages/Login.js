import React, { useState, useEffect } from 'react';
import { Link, useHistory } from "react-router-dom";
import { useDispatch, useSelector } from 'react-redux';
import { loginUser } from '../redux/actions/userActions';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const Login = () => {
   useEffect(() => {
   }, [])

   const [loginData, setLoginData] = useState({
      email: '',
      password: ''      
   }); 

   let history = useHistory();
   let dispatch = useDispatch();

   const handleSubmit = (event) => {
      event.preventDefault();

      dispatch(loginUser(loginData, history));
   }

   const handleChange = (event) => {
      setLoginData({
         ...loginData,
         [event.target.name]: event.target.value
      })
   }   

   const { errors } = useSelector(state => state.ui);    

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
                     {
                        (errors && errors.Email) && (
                           errors.Email.map((err, index) => (
                                 <Form.Text key={index} className="text-danger">{err}</Form.Text>
                              )
                           )
                        )
                     }
                  </Form.Group>
                  <Form.Group controlId="password">
                     <Form.Label>Password</Form.Label>
                     <Form.Control 
                        type="password" 
                        name="password" 
                        placeholder="Password" 
                        onChange={handleChange} 
                     />
                     {
                        (errors && errors.Password) && (
                           <Form.Text className="text-danger">
                              {errors.Password[0]}
                        </Form.Text>
                        )
                     }
                  </Form.Group>
                  <Button variant="primary" type="submit">
                     Login
                  </Button>
               </Form>
               <small>don't have an account? Sign up <Link to="/signup">here</Link></small>
            </div>
            <div className="col-lg-4"></div>
         </div>
      </div>
   )
}

export default Login