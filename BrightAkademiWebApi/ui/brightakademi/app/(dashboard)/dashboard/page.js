"use client"
import Link from 'next/link';
import React, { useEffect, useState } from 'react'
import SuperAdminScreen from './superadmin'
import AdminScreen from './admin'
import TrainerScreen from './trainer'
import TraineeScreen from './trainee'
import {router, useRouter} from 'next/navigation'

export default function Dashboard() {
  const [screen, setScreen] =useState(<></>)
  const router = useRouter()
  useEffect(()=>{
    

    if(localStorage.getItem('access')){
      const role = JSON.parse(localStorage.getItem('access')).roles[0];
    if (role==="Super Admin") {
      setScreen(<SuperAdminScreen/>)
    }
    else if (role==="Admin") {
      setScreen(<AdminScreen/>)
    }
    else if (role==="Trainer") {
      setScreen(<TrainerScreen/>)
    }
    else if (role==="Trainee") {
      setScreen(<TraineeScreen/>)
    }
    else{
      setScreen(<></>)
    }
  }else{
    setScreen(<></>)
    router.push("/")
  }

  },[])


  return (
    <>
    {
      screen
    }
    </>      
    
  )
}
