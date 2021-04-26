import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Category from './category/Category';

const Statistics = (props) => {
   const [statistics, setStatistics] = useState({});
   const [categories, setCategories] = useState([]);

   useEffect(() => {
      axios
         .get('http://localhost:5005/Statistics/Full')
         .then((res) => {
            setStatistics(res.data)
         })
         .catch((err) => console.log(err));

         axios 
            .get('http://localhost:5003/CarAds/Categories')
            .then((res) => {
               setCategories(res.data);
            })
            .catch(err => console.log(err));
   }, []);   

   return (
      <div className="container-fluid">
         { statistics && (
            <div className="row mb-5">
               <div className="col-lg-6 text-center">
                  <h3>{statistics.totalCarAds} Car Ads</h3>
               </div>
               <div className="col-lg-6 text-center">
                  <h3>{statistics.totalRentedCars} Rented Cars </h3>
               </div>
            </div>
         )}
         <div className="row">
            { categories && ( categories.map(category => <Category key={category.id} category={category} />)) }
         </div>
      </div>
   )
}

export default Statistics;