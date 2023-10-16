import Link from 'next/link'
import { useRouter } from 'next/navigation';
import React from 'react'

function Navbar() {
  const router = useRouter()
  const handleLogOut = ()=>{
    localStorage.removeItem('access');
    router.push("/login")
  }
  return (
     <nav className="main-header navbar navbar-expand navbar-white navbar-light">
     {/* Left navbar links */}
     <ul className="navbar-nav">
       <li className="nav-item">
         <a className="nav-link" data-widget="pushmenu" href="#" role="button">
           <i className="fas fa-bars" />
         </a>
       </li>
       <li className="nav-item d-none d-sm-inline-block">
         <Link href="/home" className={"nav-link"}>
           Anasayfa
         </Link>
       </li>
       <li className="nav-item d-none d-sm-inline-block">
       <Link href="/contact" className={"nav-link"}>
           İletişim
         </Link>
       </li>
     </ul>
     {/* Right navbar links */}
     <ul className="navbar-nav ml-auto">

       {/* Messages Dropdown Menu */}
       <li className="nav-item dropdown">
         <a onClick={handleLogOut}><i className="fas fa-power-off"></i> Çıkış Yap</a> 
       </li>

     </ul>
   </nav>
  )
}
 
export default Navbar