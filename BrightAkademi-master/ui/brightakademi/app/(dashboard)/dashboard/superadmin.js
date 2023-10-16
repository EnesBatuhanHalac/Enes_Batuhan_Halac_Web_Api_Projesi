"use client"
import Link from 'next/link';
import React, { useEffect, useState } from 'react'


export default function SuperAdminScreen() {
    const [dashboard, setDashboard] = useState({});
    const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access')).token;
  
    useEffect(() => {
        fetch(`${process.env.API_URL}/dashboard/superadmin`,
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
            <Link href={"/students"} className="small-box-footer">
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
                {dashboard.totalStudent}
              </h3>
              <p>Öğrenciler</p>
            </div>
            <div className="icon">
              <i className="ion ion-stats-bars" />
            </div>
            <Link href={"/students"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
          </div>
        </div>
        {/* ./col */}
        <div className="col-lg-3 col-6">
          {/* small box */}
          <div className="small-box bg-warning">
            <div className="inner">
              <h3>{dashboard.totalTeachers}</h3>
              <p>Öğretmen</p>
            </div>
            <div className="icon">
              <i className="ion ion-person-add" />
            </div>
            <Link href={"/teachers"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
          </div>
        </div>
        {/* ./col */}
        <div className="col-lg-3 col-6">
          {/* small box */}
          <div className="small-box bg-danger">
            <div className="inner">
              <h3>{dashboard.totalUsers}</h3>
              <p>Kullanıcı</p>
            </div>
            <div className="icon">
              <i className="ion ion-pie-graph" />
            </div>
            <Link href={"/users"} className="small-box-footer">
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
                    Son eklenen kullanıcılar
                  </h3>
                </div>
              </div>
              {/* /.card-header */}
              <div className="card-body">
                {
                  dashboard.lastUsers !=null ? <table id="example2" className="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>Kullanıcı adı</th>
                        <th>Şifre</th>
                        <th>Aktiflik</th>
                      </tr>
                    </thead>
                    <tbody>
                      {
                        dashboard.lastUsers.map((user, index) => {
                          return (
                            <tr key={index}>
                              <td><p style={{ whiteSpace: "nowrap" }}>{user.username}</p></td>
                              <td><p style={{}}>****************</p></td>
                              <td>
                                <div className="form-group">
                                  <div className="custom-control custom-switch custom-switch-off-danger custom-switch-on-success">
                                    <input
                                      type="checkbox"
                                      className="custom-control-input"
                                      id="customSwitch3"
                                      checked={user.isActive}
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
                    : <h4> Kullanıcı bulunmadı, yeni birtane ekleyin</h4>
                }

              </div>
              {/* /.card-body */}
              <div className="card-footer d-flex justify-content-center">
              <Link href={"/users"} className="small-box-footer">
              Tümünü gör <i className="fas fa-arrow-circle-right" />
            </Link>
              </div>
            </div>
      </div>
    </div>

  )
}
