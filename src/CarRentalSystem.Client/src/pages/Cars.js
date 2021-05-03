import React from 'react';

import AllCars from "../components/cars/AllCars";
import SearchCars from "../components/cars/SearchCars";

const Cars = () => {
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