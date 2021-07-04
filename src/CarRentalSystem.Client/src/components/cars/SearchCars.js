import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

import { search } from '../../redux/actions/carActions';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import CreateCar from './CreateCar';

const SearchCars = () => {
   const dispatch = useDispatch();
   const categories = useSelector(state => state.car.categories);
   const { authenticated } = useSelector(state => state.user);

   const [searchData, setSearchData] = useState({
      manufacturer: '',
      dealer: '',
      category: '',
      minPricePerDay: '',
      maxPricePerDay: ''
   });

   const handleSubmit = (event) => {
      event.preventDefault();   
      
      dispatch(search(searchData));
   }

   const handleChange = (event) => {
      setSearchData({
         ...searchData,
         [event.target.name]: event.target.value
      })
   }

   return (
      <div className="col-lg-3">
         <Form noValidate onSubmit={handleSubmit}>
            <Form.Group controlId="manufacturer">
               <Form.Label>Manifacturer:</Form.Label>
               <Form.Control 
                  type="text" 
                  name="manufacturer" 
                  placeholder="Enter manufacturer" 
                  onChange={handleChange}
               />
            </Form.Group>
            <Form.Group controlId="dealer">
               <Form.Label>Dealer name:</Form.Label>
               <Form.Control 
                  type="text" 
                  name="dealer" 
                  placeholder="Enter dealer" 
                  onChange={handleChange}
               />
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
            <Form.Group controlId="minPricePerDay">
               <Form.Label>Select min price per day:</Form.Label>
               <Form.Control 
                  type="number" 
                  name="minPricePerDay" 
                  placeholder="Enter min price" 
                  onChange={handleChange}
               />
            </Form.Group>
            <Form.Group controlId="maxPricePerDay">
               <Form.Label>Select max price per day:</Form.Label>
               <Form.Control 
                  type="number" 
                  name="maxPricePerDay" 
                  placeholder="Enter max price" 
                  onChange={handleChange}
               />
            </Form.Group>
            <Button variant="primary" type="submit">Search</Button>
            { authenticated && <CreateCar /> }
         </Form>
      </div>
   )
}

export default SearchCars;