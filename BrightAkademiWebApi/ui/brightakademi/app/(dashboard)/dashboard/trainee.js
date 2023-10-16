"use client"
import Link from 'next/link';
import React, { useEffect, useState } from 'react'


export default function TrainerScreen() {
    const [dashboard, setDashboard] = useState({});
    const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access')).token;
  
    useEffect(() => {
        fetch(`${process.env.API_URL}/dashboard/trainee`,
          {
            headers: new Headers({
              'content-type': 'application/json',
              Authorization: tokenStr
            }),
          }).then(res => res.json())
          .then((result) => {
            setDashboard(result);
          }).catch(e => {
            console.log(e);
          })
      },[])
  return (
    <div className="container">
      <div className="row">
        <div className="col-lg-3 col-6">
          {/* small box */}
          <div className="small-box bg-info">
            <div className="inner">
              <h3>{dashboard.totalCourses}</h3>
              <p>Kurslar</p>
            </div>
            <div className="icon">
              <i className="ion ion-bag" />
            </div>
            <Link href={"/courses"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
          </div>
        </div>
        {/* ./col */}
        <div className="col-lg-3 col-6">
          {/* small box */}
          <div className="small-box bg-success">
            <div className="inner">
              <h3>
                {dashboard.totalTeachers}
              </h3>
              <p>Öğretmenler</p>
            </div>
            <div className="icon">
              <i className="ion ion-stats-bars" />
            </div>
            <Link href={"/teachers"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
          </div>
        </div>
        {/* ./col */}
        <div className="col-lg-3 col-6">
          {/* small box */}
          <div className="small-box bg-warning">
            <div className="inner">
              <h3>{dashboard.totalLevels}</h3>
              <p>Seviyeler</p>
            </div>
            <div className="icon">
              <i className="ion ion-person-add" />
            </div>
            <Link href={"/levels"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
          </div>
        </div>
        {/* ./col */}
        <div className="col-lg-3 col-6">
          {/* small box */}
          <div className="small-box bg-danger">
            <div className="inner">
              <h3>{dashboard.totalCategories}</h3>
              <p>Kategoriler</p>
            </div>
            <div className="icon">
              <i className="ion ion-pie-graph" />
            </div>
            <Link href={"/categories"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
          </div>
        </div>
        {/* ./col */}
      </div>
      <div className="row">
        
      <div className="card w-100">
              <div className="card-header " >
                <div className='d-flex justify-content-between'>
                  <h3 className="card-title">
                    Derslerim
                  </h3>
                </div>
              </div>
              {/* /.card-header */}
              <div className="card-body">
                {
                      dashboard.myCourses!=null? <table id="example2" className="table table-bordered table-hover">
                        <thead>
                          <tr>
                            <th>İsim</th>
                            <th>Toplam Süre</th>
                            <th>Ay</th>
                            <th>Başlangıç Tarihi</th>
                            <th>Bitiş Tarihi</th>
                            <th>Fiyat</th>
                            <th>Aktiflik</th>
                          </tr>
                        </thead>
                        <tbody>
                          {
                            dashboard.myCourses.map((course, index) => {
                              return (
                                <tr key={index}>
                                  <td><p style={{ whiteSpace: "nowrap" }}>{course.name}</p></td>
                                  <td>{course.totalCourseHours}</td>
                                  <td>{course.howManyMonths}</td>
                                  <td>{new Date(course.startCourseTime).toLocaleDateString("tr-TR")}</td>
                                  <td>{new Date(course.finishCourseTime).toLocaleDateString("tr-TR")}</td>
                                  <td>{course.price}</td>
                                  <td>
                                    <div className="form-group">
                                      <div className="custom-control custom-switch custom-switch-off-danger custom-switch-on-success">
                                        <input
                                          type="checkbox"
                                          className="custom-control-input"
                                          id="customSwitch3"
                                          checked={course.isActive}
                                          readOnly
                                        />
                                        <label className="custom-control-label" htmlFor="customSwitch3">
      
                                        </label>
                                      </div>
                                    </div>
                                  </td>
                                </tr>
                              )
                            })
                          }
      
                        </tbody>
                      </table>
                      : <h4> Kurs bulunmadı, yeni birtane ekleyin</h4>

                }

              </div>
              {/* /.card-body */}
              <div className="card-footer d-flex justify-content-center">
              <Link href={"/courses"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
              </div>
            </div>
      </div>
        
      <div className="card w-100">
              <div className="card-header " >
                <div className='d-flex justify-content-between'>
                  <h3 className="card-title">
                    Öğrencilerim
                  </h3>
                </div>
              </div>
              {/* /.card-header */}
              <div className="card-body">
                {
           dashboard.myStudents ? <table id="example2" className="table table-bordered table-hover">
           <thead>
             <tr>
               <th>İsim</th>
               <th>Soyad</th>
               <th>Durum</th>
               <th>Kurslar</th>
               <th>Aktiflik</th>
               <th>Düzenle</th>
               <th>Sil</th>
             </tr>
           </thead>
           <tbody>
             {
               dashboard.myStudents.map((student, index) => {
                 return (
                   <tr key={index}>
                     <td><p style={{ whiteSpace: "nowrap" }}>{student.firstName}</p></td>
                     <td><p style={{ whiteSpace: "nowrap" }}>{student.lastName}</p></td>
                     <td><p style={{ whiteSpace: "nowrap" }}>{student.educationalStatus}</p></td>
                     <td>
                       <Link href={`/students/${student.id}`}
                       ><i className="fas fa-book-open"></i></Link>
                     </td>
                     <td>
                       <div className="form-group">
                         <div className="custom-control custom-switch custom-switch-off-danger custom-switch-on-success">
                           <input
                             type="checkbox"
                             className="custom-control-input"
                             id="customSwitch3"
                             checked={student.isActive}
                             readOnly
                           />
                           <label className="custom-control-label" htmlFor="customSwitch3">

                           </label>
                         </div>
                       </div>
                     </td>
                     <td>
                       <a className='text-warning'
                         onClick={() => handleItem2Update(student)}
                       ><i className="fas fa-edit"></i></a>
                     </td>
                     <td>
                       <a
                         onClick={() => handleItem2Delete(student)}
                         className='text-danger' ><i className="fas fa-trash"></i></a>
                     </td>
                   </tr>
                 )
               })
             }

           </tbody>
           <tfoot>
             <tr>
               <th>İsim</th>
               <th>Soyad</th>
               <th>Durum</th>
               <th>Kurslar</th>
               <th>Aktiflik</th>
               <th>Düzenle</th>
               <th>Sil</th>
             </tr>
           </tfoot>
         </table>
           : <h4> Öğrenci bulunmadı, yeni birtane ekleyin</h4>

                }

              </div>
              {/* /.card-body */}
              <div className="card-footer d-flex justify-content-center">
              <Link href={"/courses"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
              </div>
            </div>
      </div>

  )
}
