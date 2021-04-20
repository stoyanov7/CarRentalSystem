import Carousel from 'react-bootstrap/Carousel'

export default function Home() {
   return (
      <div className="container-fluid">
         <div className="row">
            <div className="col-lg-12">
            <Carousel>
               <Carousel.Item>
                  <img
                     className="d-block w-100"
                     src="https://cdn.wallpapersafari.com/28/85/yfgvbo.jpg"
                     alt="First slide"
                  />
               </Carousel.Item>
               <Carousel.Item>
                  <img
                     className="d-block w-100"
                     src="https://cdn.wallpapersafari.com/8/69/akX8JA.jpg"
                     alt="Second slide"
                  />
               </Carousel.Item>
            </Carousel>
            </div>
         </div>
      </div>
   )
}