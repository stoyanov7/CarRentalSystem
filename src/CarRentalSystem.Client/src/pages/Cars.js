import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { getCaterories } from '../redux/actions/carActions';

import AllCars from "../components/cars/AllCars";
import SearchCars from "../components/cars/SearchCars";

const Cars = () => {
   let dispatch = useDispatch();

   useEffect(() => {
      dispatch(getCaterories());
   }, [dispatch])

   return (     
      <div className="container-fluid">
         <div className="row">
            <SearchCars />
            <AllCars />
         </div>
      </div>
   )
} 

export default Cars;