import React, { useState } from 'react';
import { Link, useHistory } from "react-router-dom";
import { useDispatch } from 'react-redux';
import axios from 'axios';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const Login = () => {
   const [loginData, setLoginData] = useState({
      email: '',
      password: '',
      errors: {}
   });

   let history = useHistory();
   let dispatch = useDispatch();

   const handleSubmit = (event) => {
      event.preventDefault();

      axios.post('http://localhost:5001/Identity/Login', loginData)
      .then(function (res) {
         const token = `Bearer ${res.data.token}`;
         localStorage.setItem('token', token);
         axios.defaults.headers.common['Authorization'] = token;

         dispatch({ type: 'SET_AUTHENTICATED' });

         history.push('/');
      })
      .catch((err) => {        
         const errors = err.response.data.errors;
         setLoginData({ ...loginData, errors });
      });
   }

   const handleChange = (event) => {
      setLoginData({
         ...loginData,
         [event.target.name]: event.target.value
      })
   }

   const { errors } = loginData;

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
                        errors.Email && (
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
                        errors.Password && (
                           <Form.Text className="text-danger">
                              {errors.Password[0]}
                        </Form.Text>
                        )
                     }
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

export default Login