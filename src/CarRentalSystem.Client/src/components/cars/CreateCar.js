import React, { useState, useEffect, useCallback } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { createNewCar, clearErrors } from '../../redux/actions/carActions';

import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';

const CreateCar = () => {
   const dispatch = useDispatch();
   const categories = useSelector(state => state.car.categories);
   const { errors } = useSelector(state => state.ui);  

   const [show, setShow] = useState(false);

   const [createCarData, setCreateCarData] = useState({
      manufacturer: '',
      model: '',
      category: 1,
      imageUrl: '',
      pricePerDay: 0,
      hasClimateControl: false,
      numberOfSeats: 0,
      transmissionType: 0
   });   

   const handleClose = useCallback(() => { 
      dispatch(clearErrors());
      setShow(false); 
   }, [dispatch]);

   const handleShow = () => setShow(true);

   useEffect(() => {
      if (errors === undefined || errors === null) {
         handleClose();
      }
   }, [errors, handleClose]);

   const handleSubmit = (event) => {
      event.preventDefault();

      dispatch(createNewCar(createCarData));
   }

   const handleChange = (event) => {
      setCreateCarData({
         ...createCarData,
         [event.target.name]: event.target.value
      })
   } 

   return (
      <>       
         <Button 
            variant="success" 
            className="float-right" 
            type="button" 
            onClick={handleShow}
         >
            Create car
         </Button>  
         <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
               <Modal.Title>Create new car</Modal.Title>
            </Modal.Header>
            <form onSubmit={handleSubmit}>
               <Modal.Body>         
                  <Form.Group controlId="manufacturer">
                     <Form.Label>Manifacturer:</Form.Label>
                     <Form.Control 
                        type="text" 
                        name="manufacturer" 
                        placeholder="Enter manufacturer"   
                        onChange={handleChange}                
                     />
                     {
                        (errors && errors.Manufacturer) && (
                           errors.Manufacturer.map((err, index) => (
                                 <Form.Text key={index} className="text-danger">{err}</Form.Text>
                              )
                           )
                        )
                     }
                  </Form.Group>
                  <Form.Group controlId="model">
                     <Form.Label>Model:</Form.Label>
                     <Form.Control 
                        type="text" 
                        name="model" 
                        placeholder="Enter model" 
                        onChange={handleChange}                  
                     />
                     {
                        (errors && errors.Model) && (
                           errors.Model.map((err, index) => (
                                 <Form.Text key={index} className="text-danger">{err}</Form.Text>
                              )
                           )
                        )
                     }
                  </Form.Group>
                  <Form.Group controlId="category">
                     <Form.Label>Category:</Form.Label>
                     <Form.Control 
                        as="select"
                        custom
                        name="category"     
                        onChange={handleChange}             
                     >
                        { categories && (categories.map(c => <option key={c.id} value={c.id}>{c.name}</option>)) }
                     </Form.Control>
                  </Form.Group>
                  <Form.Group controlId="imageUrl">
                     <Form.Label>Image URL:</Form.Label>
                     <Form.Control 
                        type="text" 
                        name="imageUrl" 
                        placeholder="Image URL" 
                        onChange={handleChange}
                     />
                     {
                        (errors && errors.ImageUrl) && (
                           errors.ImageUrl.map((err, index) => (
                                 <Form.Text key={index} className="text-danger">{err}</Form.Text>
                              )
                           )
                        )
                     }
                  </Form.Group>
                  <Form.Group controlId="pricePerDay">
                     <Form.Label>Price per day:</Form.Label>
                     <Form.Control 
                        type="number" 
                        name="pricePerDay" 
                        placeholder="Enter price" 
                        onChange={handleChange}
                     />
                  </Form.Group>
                  <Form.Group controlId="hasClimateControl">
                     <span>Has climate control:</span>
                     <label>
                        <input                        
                           className="ml-2"
                           type="radio"
                           value={true}
                           name="hasClimateControl"
                           onChange={handleChange}
                        />
                        Yes
                     </label>
                     <label>
                        <input                        
                           className="ml-2"
                           type="radio"
                           value={false}
                           name="hasClimateControl"
                           onChange={handleChange}
                        />
                        No
                     </label>
               </Form.Group>  
                  <Form.Group controlId="numberOfSeats">
                     <Form.Label>Number of seats:</Form.Label>
                     <Form.Control 
                        type="number" 
                        name="numberOfSeats" 
                        placeholder="Enter seats" 
                        onChange={handleChange}
                     />
                     {
                        (errors && errors.NumberOfSeats) && (
                           errors.NumberOfSeats.map((err, index) => (
                                 <Form.Text key={index} className="text-danger">{err}</Form.Text>
                              )
                           )
                        )
                     }
                  </Form.Group>   
                  <Form.Group controlId="transmissionType">
                        <Form.Label>Transmission type:</Form.Label>
                        <Form.Control 
                           as="select"
                           custom
                           name="transmissionType"
                           onChange={handleChange}
                        >
                           <option key="1" value={1}>Manual</option>
                           <option key="2" value={2}>Automatic</option>
                        </Form.Control>
                     </Form.Group>  
               </Modal.Body>
               <Modal.Footer>
                  <Button variant="secondary" type="button" onClick={handleClose}>
                     Close
                  </Button>
                  <Button variant="success" type="button" onClick={handleSubmit}>
                     Save
                  </Button>  
               </Modal.Footer>
            </form>
         </Modal>
      </>
    );
}

export default CreateCar;