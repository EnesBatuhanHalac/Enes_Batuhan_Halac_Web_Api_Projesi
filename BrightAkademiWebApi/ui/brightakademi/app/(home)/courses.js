"use client"
import React, { useEffect, useState } from 'react'

export default function Courses() {
  const [items, setItems] = useState([]);
  const [isLoaded, setIsLoaded] = useState(false);
  const [categories, setCategories] = useState([])
  const [categoryId, setCategoryId] = useState(0)

  const randomNum = () => {
    const randomNumber = Math.floor(Math.random() * 6) + 1;
    return randomNumber;
  }

  useEffect(() => {
    fetch(`${process.env.API_URL}/courses/detailList/${categoryId}`, {
      headers: new Headers({
        'content-type': 'application/json',
      }),
    }).then((res) => {
      return res.json();
    }).then(
      (result) => {
        setIsLoaded(true);
        setItems(result.data);
      },
      (error) => {
        setHasError(true);
      }
    )
  }, [categoryId])

  useEffect(() => {
    fetch(`${process.env.API_URL}/categories`)
      .then(res => res.json())
      .then(
        (result) => {
          setCategories(result.data);
        },
      )
  }, []
  )
  return (
    <div className="courses-area section-padding40 fix">
      <div className="container">
        <div className="row justify-content-center">
          <div className="col-xl-7 col-lg-8">
            <div className="section-tittle text-center mb-55">
              <h2>Öne çıkan kurslarımız</h2>
            </div>
          </div>
        </div>
        <div className="row ">
          <div className="w-100 mb-5 d-flex justify-content-center">
            <select className="form-control select2 col-6" onChange={(e) => setCategoryId(e.target.value)}>
              <option disabled defaultValue={-1} >Seçiniz</option>
              {
                categories.map((item, index) => {
                  return (
                    <option key={index} value={item.id} >{item.name}</option>
                  )
                })
              }

            </select>
          </div>
        </div>

        <div className="row">
          {
            items.map((course, index) => {
              return (
                <div key={index} className="col-lg-4">
                  <div className="properties properties2 mb-30">
                    <div className="properties__card">
                      <div className="properties__img overlay1">
                        <a href="#">
                          <img src={`assets/img/gallery/featured${randomNum()}.png`} alt="" />
                        </a>
                      </div>
                      <div className="properties__caption">
                        <p>{course.category.name}</p>
                        <h3>
                          <a href="#">{course.name}</a>
                        </h3>
                        <p>
                          {course.description}
                        </p>
                        <div className="properties__footer d-flex justify-content-between align-items-center">
                          <div className="restaurant-name">
                            <div className="rating">
                              <i className="fas fa-star" />
                              <i className="fas fa-star" />
                              <i className="fas fa-star" />
                              <i className="fas fa-star" />
                              <i className="fas fa-star-half" />
                            </div>
                            <p>
                              <span>(4.5)</span> {course.totalCourseHours} saat
                            </p>
                          </div>
                          <div className="price">
                            <span>₺{course.price}</span>
                          </div>
                        </div>
                        <a href="#" className="border-btn border-btn2">
                          Kayıt Ol
                        </a>
                      </div>
                    </div>
                  </div>
                </div>
              )
            })
          }
        </div>
        <div className="row justify-content-center">
          <div className="col-xl-7 col-lg-8">
            <div className="section-tittle text-center mt-40">
              <a href="#" className="border-btn">
                Tümünü gör
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
