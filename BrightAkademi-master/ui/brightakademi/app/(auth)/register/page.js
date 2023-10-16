"use client"
import React, { useContext, useState } from 'react'
import { toast } from 'react-toastify';
import { useRouter } from 'next/navigation';
function page() {
  const [isLoaded, setIsLoaded] = useState(false);
  const [inputField, setInputField] = useState({})
  const router = useRouter()
  const inputsHandler = (e) => {
    const newValue = e.target.type === 'checkbox' ? e.target.checked : e.target.value;
    setInputField({ ...inputField, [e.target.name]: newValue })
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    var obj = JSON.stringify(inputField);
    fetch(`${process.env.API_URL}/auth/register`, {
      body: obj,
      headers: new Headers({ 'content-type': 'application/json' }),
      method: "POST"
    }).then((res) => { return res.json() })
      .then(
        (result) => {
          if (result) {
            var access = JSON.stringify(result)
            localStorage.setItem("access", access)
            if (result.role === "Trainer") {
              router.push("/home")
            }
            else {
              router.push("/dashboard")
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
            <label htmlFor="firstname">Ad</label>
            <input
              value={inputField.firstname}
              onChange={inputsHandler}
              type="text" name="firstname" placeholder="" />
          </div>
          <div className="form-input">
            <label htmlFor="lastname">Soyad</label>
            <input
              value={inputField.lastname}
              onChange={inputsHandler}
              type="text" name="lastname" placeholder="" />
          </div>
          <div className="form-input">
            <label htmlFor="username">Kullanıcı adı</label>
            <input
              value={inputField.username}
              onChange={inputsHandler}
              type="text" name="username" placeholder="" />
          </div>
          <div className="form-input">
            <label htmlFor="name">Şifre</label>
            <input
              value={inputField.password}
              onChange={inputsHandler}
              type="password" name="password" />
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

export default page