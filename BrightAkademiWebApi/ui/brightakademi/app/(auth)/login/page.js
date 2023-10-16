"use client"
import React, { useContext, useState } from 'react'
import { toast } from 'react-toastify';
import { useRouter } from 'next/navigation';
function login() {
  const [isLoaded, setIsLoaded] = useState(false);
  const [isValidUser, setIsValidUser] = useState(true);
  const [isValidPassword, setIsValidPassword] = useState(true);
  const [inputField, setInputField] = useState({username:'', password:''})
  const router = useRouter()
  const inputsHandler = (e) => {
    const newValue = e.target.type === 'checkbox' ? e.target.checked : e.target.value;
    setInputField({ ...inputField, [e.target.name]: newValue })
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    var obj = JSON.stringify(inputField);
    fetch(`${process.env.API_URL}/auth/login`, {
      body: obj,
      headers: new Headers({ 'content-type': 'application/json' }),
      method:"POST"
    }).then(res =>res.json())
      .then(
        (result) => {
          if(result){
            if(result.statusCode===404){
              setIsValidUser(false)
            }
            else if(result.statusCode===400){
              setIsValidPassword(false)
            }
            else{
              var access = JSON.stringify(result)
              localStorage.setItem("access",access)
              if(result.role==="Trainer"){
                router.push("/home")
              }
              else{
                router.push("/dashboard")
              }
            }
      
          }
 
        },
      )     
  }


  const video = "assets/img/login-bg.mp4";
  return (
    <main className="login-body">
      <video autoPlay muted loop>
        <source src={video} type="video/mp4" />
      </video>
      {/* Login Admin */}
      <form className="form-default">
        <div className="login-form">
          {/* logo-login */}
          <div className="logo-login">
            <a href="index.html">
              <img src="assets/img/logo/loder.png" alt="" />
            </a>
          </div>
          <h2>Giriş Yapın</h2>
          <div className="form-input">
            <label htmlFor="username">User Name</label>
            <input
              value={inputField.username}
              onChange={inputsHandler}
              type="text" name="username" placeholder="Username" />
           <div style={{display: isValidUser? 'none': 'flex'}} className="invalid-feedback">
                Kullanıcı bulunamadı
              </div>
          </div>
          
          <div className="form-input">
            <label htmlFor="name">Şifre</label>
            <input
              value={inputField.password}
              onChange={inputsHandler}
              type="password" name="password" placeholder="Şifre" />
              <div style={{display: isValidPassword? 'none': 'flex'}} className="invalid-feedback">
                Şifre yanlış
              </div>
          </div>
          <div className="form-input pt-30">
            <input onClick={handleSubmit} type="submit" name="submit" defaultValue="Giriş" />
          </div>
          {/* Forget Password */}
          <a href="#" className="forget">
            Şifremi unuttum
          </a>
          {/* Forget Password */}

        </div>
      </form>
      {/* /end login form */}
    </main>
  )
}

export default login