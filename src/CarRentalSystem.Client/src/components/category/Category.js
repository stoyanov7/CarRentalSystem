import React from 'react';
import styles from './Category.module.css';

const Category = (props) => {
   const { name, description, totalCarAds } = props.category; 

   return (
      <div className="col-lg-4">
         <div className={styles.box}>
               <div className="header">
                  <h4>{name}</h4>
               </div>
               <hr />
               <div className="body">
                  {description}
               </div>
               <hr />
               <div className={styles.action}>
                  <button className="btn btn-primary">Go and see all {totalCarAds} cars</button>
               </div>
         </div>
      </div>
   )
}

export default Category;