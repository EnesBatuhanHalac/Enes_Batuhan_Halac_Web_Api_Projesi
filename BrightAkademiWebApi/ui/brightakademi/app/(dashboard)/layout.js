"use client"
import { useState } from 'react';
import './dashboard.css';
import '/node_modules/react-toastify/dist/ReactToastify.min.css'
import { ToastContainer } from 'react-toastify';
import Footer from './footer';
import Navbar from './navbar';
import Link from 'next/link';
import  useTokenExpirationCheck from '@/app/hooks/useTokenExpirationCheck'
import Sidebar from './sidebar';


export default function DashboardLayout({ children }) {
  useTokenExpirationCheck()
  const [isLoaded, setIsLoaded] = useState(true)
  const access = JSON.parse(localStorage.getItem('access'));
  const name = access?.name;


  return (
    <>
      <html>
        <head>
          <meta charSet="utf-8" />
          <meta name="viewport" content="width=device-width, initial-scale=1" />
          <title> Bright Eğitimleri</title>
          {/* Google Font: Source Sans Pro */}
          <link
            rel="stylesheet"
            href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback"
          />
          {/* Font Awesome */}
          <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
          {/* Ionicons */}
          <link
            rel="stylesheet"
            href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"
          />
          {/* Tempusdominus Bootstrap 4 */}
          <link
            rel="stylesheet"
            href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"
          />
          {/* iCheck */}
          <link
            rel="stylesheet"
            href="plugins/icheck-bootstrap/icheck-bootstrap.min.css"
          />
          {/* JQVMap */}
          <link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css" />
          {/* Theme style */}
          <link rel="stylesheet" href="dist/css/adminlte.min.css" />
          {/* overlayScrollbars */}
          <link
            rel="stylesheet"
            href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css"
          />
          {/* Daterange picker */}
          <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css" />
          {/* summernote */}
          <link rel="stylesheet" href="plugins/summernote/summernote-bs4.min.css" />
          {/* Tostify */}
        </head>
        <body>
          <div className="wrapper">
            {/* Preloader */}
            {
              <div style={{ display: isLoaded ? "none" : "flex" }} className="preloader flex-column justify-content-center align-items-center">
                <img
                  className="animation__shake"
                  src="dist/img/AdminLTELogo.png"
                  alt="AdminLTELogo"
                  height={60}
                  width={60}
                />
              </div>
            }

            <Navbar />
            {/* Main Sidebar Container */}
            <aside className="main-sidebar sidebar-dark-primary elevation-4">
              {/* Brand Logo */}

              {/* Sidebar */}
              <div className="sidebar">
                {/* Sidebar user panel (optional) */}
                <div className="user-panel mt-3 pb-3 mb-3 d-flex">
                  <div className="image">
                    <img
                      src="dist/img/user2-160x160.jpg"
                      className="img-circle elevation-2"
                      alt="User Image"
                    />
                  </div>
                  <div className="info">
                  <span className='text-white'>
                      {name}
                      </span>
                   
                    <a href="#" className="d-block">
                    {/* {access.roles =='Trainer' ? 'Eğitmen' : access.roles == 'Trainee' ? 'Öğrenci' : access.roles==='SSuper Admin':access.roles=='Admin'} */}
                    </a>
                      
                  </div>
                </div>
                {/* SidebarSearch Form */}
                <div className="form-inline">
                  <div className="input-group" data-widget="sidebar-search">
                    <input
                      className="form-control form-control-sidebar"
                      type="search"
                      placeholder="Search"
                      aria-label="Search"
                    />
                    <div className="input-group-append">
                      <button className="btn btn-sidebar">
                        <i className="fas fa-search fa-fw" />
                      </button>
                    </div>
                  </div>
                </div>
                {/* Sidebar Menu */}
                  <Sidebar/>
                {/* /.sidebar-menu */}
              </div>
              {/* /.sidebar */}
            </aside>
            {/* Content Wrapper. Contains page content */}
            <div className="content-wrapper">
              <br />
              <ToastContainer />
              {/* <Provider> */}
              {children}
              {/* </Provider> */}
            </div>
            {/* /.content-wrapper */}
            <Footer />
          </div>
        </body>
      </html>
    </>


  );
}
