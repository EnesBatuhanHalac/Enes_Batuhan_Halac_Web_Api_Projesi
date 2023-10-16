import React from 'react'
import Courses from '../courses'
import Categories from '../categories'

function Course() {
  return (
    <main>
  {/*? slider Area Start*/}
  <section className="slider-area slider-area2">
    <div className="slider-active">
      {/* Single Slider */}
      <div className="single-slider slider-height2">
        <div className="container">
          <div className="row">
            <div className="col-xl-8 col-lg-11 col-md-12">
              <div className="hero__caption hero__caption2">
                <h1 data-animation="bounceIn" data-delay="0.2s">
                  Online Eğitim
                </h1>
                {/* breadcrumb Start*/}
                <nav aria-label="breadcrumb">
                  <ol className="breadcrumb">
                    <li className="breadcrumb-item">
                      <a href="index.html">Anasayfa</a>
                    </li>
                    <li className="breadcrumb-item">
                      <a href="#">Kurslar</a>
                    </li>
                  </ol>
                </nav>
                {/* breadcrumb End */}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
  {/* Courses area start */}
    <Courses/>
  {/* Courses area End */}
  {/*? top subjects Area Start */}
    <Categories/>
  {/* top subjects End */}
  {/* ? services-area */}
  <div className="services-area services-area2 section-padding40">
    <div className="container">
      <div className="row justify-content-sm-center">
        <div className="col-lg-4 col-md-6 col-sm-8">
          <div className="single-services mb-30">
            <div className="features-icon">
              <img src="assets/img/icon/icon1.svg" alt="" />
            </div>
            <div className="features-caption">
              <h3>60+ UX courses</h3>
              <p>The automated process all your website tasks.</p>
            </div>
          </div>
        </div>
        <div className="col-lg-4 col-md-6 col-sm-8">
          <div className="single-services mb-30">
            <div className="features-icon">
              <img src="assets/img/icon/icon2.svg" alt="" />
            </div>
            <div className="features-caption">
              <h3>Expert instructors</h3>
              <p>The automated process all your website tasks.</p>
            </div>
          </div>
        </div>
        <div className="col-lg-4 col-md-6 col-sm-8">
          <div className="single-services mb-30">
            <div className="features-icon">
              <img src="assets/img/icon/icon3.svg" alt="" />
            </div>
            <div className="features-caption">
              <h3>Life time access</h3>
              <p>The automated process all your website tasks.</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</main>

  )
}

export default Course