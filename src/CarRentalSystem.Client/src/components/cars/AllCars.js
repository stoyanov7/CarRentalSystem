import React, { useEffect } from "react";
import { useDispatch, useSelector } from 'react-redux';

import { search } from '../../redux/actions/carActions';

import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';

const AllCars = () => {
   let dispatch = useDispatch();

   useEffect(() => {
      dispatch(search());
   }, [dispatch]);

   const { loading } = useSelector(state => state.ui);
   const { carAds } = useSelector(state => state.car)
   
   const NoCarsFound = () => {
      return (
         <div>
            <h1>No cars found</h1>
         </div>
      )
   }

   const ListCarAds = (props) => {
      const { carAds } = props;      
      
      return (         
         carAds.map(carAd => (
            <div key={carAd.id} className="col-lg-2">
               <Card>
                  <Card.Img variant="top" src={carAd.imageUrl} />
                  <Card.Body>
                     <Card.Title>{carAd.manufacturer}</Card.Title>
                     <Card.Text>Model: {carAd.model}</Card.Text>
                     <Card.Text>Price per day: ${carAd.pricePerDay}</Card.Text>
                     <Card.Text>Category: {carAd.category}</Card.Text>
                     <Button variant="primary" type="button">Details</Button>
                  </Card.Body>
               </Card>
            </div>
         ))
      )
   }

   return (!loading && Object.keys(carAds).length > 0) ? <ListCarAds carAds={carAds} /> : <NoCarsFound />
}

export default AllCars;