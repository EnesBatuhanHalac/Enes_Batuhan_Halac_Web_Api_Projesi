"use client"
import React from 'react'
import Footer from './footer'
import Navbar from './navbar'
import { ToastContainer } from 'react-toastify'
import  useTokenExpirationCheckForHome from '@/app/hooks/useTokenExpirationCheckForHome'
function HomeLayout({children}) {
  useTokenExpirationCheckForHome()
  return (
<html>
<head>
<meta charSet="utf-8" />
  <meta httpEquiv="x-ua-compatible" content="ie=edge" />
  <title>Courses | Education</title>
  <meta name="description" content="" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.ico" />
  {/* CSS here */}
  <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
  <link rel="stylesheet" href="assets/css/owl.carousel.min.css" />
  <link rel="stylesheet" href="assets/css/slicknav.css" />
  <link rel="stylesheet" href="assets/css/flaticon.css" />
  <link rel="stylesheet" href="assets/css/progressbar_barfiller.css" />
  <link rel="stylesheet" href="assets/css/gijgo.css" />
  <link rel="stylesheet" href="assets/css/animate.min.css" />
  <link rel="stylesheet" href="assets/css/animated-headline.css" />
  <link rel="stylesheet" href="assets/css/magnific-popup.css" />
  <link rel="stylesheet" href="assets/css/fontawesome-all.min.css" />
  <link rel="stylesheet" href="assets/css/themify-icons.css" />
  <link rel="stylesheet" href="assets/css/slick.css" />
  <link rel="stylesheet" href="assets/css/nice-select.css" />
  <link rel="stylesheet" href="assets/css/style.css" />
</head>
<body>
  
    <Navbar/>
    <ToastContainer />
    {children}
    <Footer/>
  {/* Scroll Up */}
  <div id="back-top">
    <a title="Go to Top" href="#">
      <i className="fas fa-level-up-alt" />
    </a>
  </div>
</body>
</html>

  )
}

export default HomeLayout