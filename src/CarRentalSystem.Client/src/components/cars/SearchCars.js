import React from 'react';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const SearchCars = () => {
   return (
      <div className="col-lg-3">
         <Form noValidate>
            <Form.Group controlId="manufacturer">
               <Form.Label>Manifacturer:</Form.Label>
               <Form.Control 
                  type="text" 
                  name="manufacturer" 
                  placeholder="Enter manufacturer" 
               />
            </Form.Group>
            <Form.Group controlId="dealer">
               <Form.Label>Dealer name:</Form.Label>
               <Form.Control 
                  type="text" 
                  name="dealer" 
                  placeholder="Enter dealer" 
               />
            </Form.Group>
            <Form.Group controlId="category">
               <Form.Label>Category:</Form.Label>
               <Form.Control 
                  as="select"
                  custom
                  name="category"
               />
            </Form.Group>
            <Form.Group controlId="minPricePerDay">
               <Form.Label>Select min price per day:</Form.Label>
               <Form.Control 
                  type="number" 
                  name="minPricePerDay" 
                  placeholder="Enter min price" 
               />
            </Form.Group>
            <Form.Group controlId="maxPricePerDay">
               <Form.Label>Select max price per day:</Form.Label>
               <Form.Control 
                  type="number" 
                  name="maxPricePerDay" 
                  placeholder="Enter max price" 
               />
            </Form.Group>
            <Button variant="primary">Search</Button>
         </Form>
      </div>
   )
}

export default SearchCars;