import React, { useEffect, useState } from "react";
import axios from 'axios';
import { environment } from '../../environments/environment';

import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';

const AllCars = () => {
   const [carAds, setCarAds] = useState([]);

   useEffect(() => {
      axios
         .get(`${environment.dealersApiUrl}/CarAds/Search`)
         .then((res) => {
            setCarAds(res.data.carAds);
         })
   }, []);

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
                     <Card.Text>{carAd.pricePerDay}</Card.Text>
                     <Button variant="primary">Details</Button>
                  </Card.Body>
               </Card>
            </div>
         ))
      )
   }

   return carAds.length !== 0 ? <ListCarAds carAds={carAds} /> : <NoCarsFound />
}

export default AllCars;