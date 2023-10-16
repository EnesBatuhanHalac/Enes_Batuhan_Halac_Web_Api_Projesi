"use client"
import React, { useEffect, useState } from 'react'

export default function Teachers() {
  const [items, setItems] = useState([]);
  const [isLoaded, setIsLoaded] = useState(false);

  const randomNum = () => {
    const randomNumber = Math.floor(Math.random() * 4) + 1;
    return randomNumber;
  }

  useEffect(() => {
    fetch(`${process.env.API_URL}/teachers`)
      .then(res => res.json())
      .then(
        (result) => {
          setItems(result.data);
        },
      )
  }, []
  )
  return (
    <section className="team-area section-padding40 fix">
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-xl-7 col-lg-8">
          <div className="section-tittle text-center mb-55">
            <h2>Eğitimciler </h2>
          </div>
        </div>
      </div>
      <div className="team-active">
       { items.map((item,index)=>{
          return(
            <div key={index} className="single-cat text-center">
          <div className="cat-icon">
            <img src={`assets/img/gallery/team${randomNum()}.png`} alt="" />
          </div>
          <div className="cat-cap">
            <h5>
              <a >{item.firstName+" "+ item.lastName}</a>
            </h5>
            <p>{item.profession}</p>
          </div>
        </div>
          )
        })}
      </div>
    </div>
  </section>
  )
}
