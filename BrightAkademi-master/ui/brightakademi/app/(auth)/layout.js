import React from 'react'
import { ToastContainer } from 'react-toastify'

export default function LayoutAuth({children}) {
  return (
<html>
  <head>
    
  <meta charSet="utf-8" />
  <meta httpEquiv="x-ua-compatible" content="ie=edge" />
  <title> App landing</title>
  <meta name="description" content="" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.ico" />
  {/* CSS here */}
  <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
  <link rel="stylesheet" href="assets/css/style.css" />
  </head>
  <body>
    {/* ? Preloader Start */}
  {/* <div id="preloader-active">
    <div className="preloader d-flex align-items-center justify-content-center">
      <div className="preloader-inner position-relative">
        <div className="preloader-circle" />
        <div className="preloader-img pere-text">
          <img src="assets/img/logo/loder.png" alt="" />
        </div>
      </div>
    </div>
  </div> */}
  {/* Preloader Start*/}
    <ToastContainer/>
  {children}
  {/* Jquery, Popper, Bootstrap */}
  {/* Jquery Mobile Menu */}
  {/* Video bg */}
  {/* Jquery Slick , Owl-Carousel Plugins */}
  {/* One Page, Animated-HeadLin */}
  {/* Date Picker */}
  {/* Nice-select, sticky */}
  {/* Progress */}
  {/* counter , waypoint,Hover Direction */}
  {/* contact js */}
  {/* Jquery Plugins, main Jquery */}
  </body>
  
</html>

  )
}

