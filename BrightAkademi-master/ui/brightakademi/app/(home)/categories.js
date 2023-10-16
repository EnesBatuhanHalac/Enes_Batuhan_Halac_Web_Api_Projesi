"use client"
import React, { useEffect, useState } from 'react'

export default function Categories() {
  const [items, setItems] = useState([]);
  const [isLoaded, setIsLoaded] = useState(false);

  const randomNum = () => {
    const randomNumber = Math.floor(Math.random() * 8) + 1;
    return randomNumber;
  }

  useEffect(() => {
    fetch(`${process.env.API_URL}/categories`)
      .then(res => res.json())
      .then(
        (result) => {
          setItems(result.data);
        },
      )
  }, []
  )
  return (
    <div className="topic-area">
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-xl-7 col-lg-8">
          <div className="section-tittle text-center mb-55">
            <h2>Eğitim kategorilerimiz</h2>
          </div>
        </div>
      </div>
      <div className="row">
        {
          items.map((item, index)=>{
            return(
              <div key={index} className="col-lg-3 col-md-4 col-sm-6">
              <div className="single-topic text-center mb-30">
                <div className="topic-img">
                  <img src={`assets/img/gallery/topic${randomNum()}.png`} alt="" />
                  <div className="topic-content-box">
                    <div className="topic-content">
                      <h3>
                        <a href="#">{item.name}</a>
                      </h3>
                    </div>
                  </div>
                </div>
              </div>
            </div>
    
            )
          })
        }
      </div>
      <div className="row justify-content-center">
        <div className="col-xl-12">
          <div className="section-tittle text-center mt-20">
            <a href="courses.html" className="border-btn">
              Daha fazla konuları gör
            </a>
          </div>
        </div>
      </div>
    </div>
  </div>
  )
}
