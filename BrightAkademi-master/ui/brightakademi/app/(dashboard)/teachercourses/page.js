"use client"
import React, { useEffect, useState } from 'react'
export default function MyCourses() {
  const [items, setItems] = useState([]);
  const [students, setStudents] = useState([]);
  const [isLoaded, setIsLoaded] = useState(false);
  const [hasError, setHasError] = useState(null);
  const [visibleItem, setVisibileItem] = useState(-1);
  const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access')).token;
  const handleToggle =(index, id)=>{
    fetchStudents(id);
    if (visibleItem===index) {
      setVisibileItem(-1)
    }
    setVisibileItem(index)
  }
  useEffect(() => {
    fetch(`${process.env.API_URL}/courses/teachercourses`, {
      headers: new Headers({
        'content-type': 'application/json',
        Authorization: tokenStr
      }),
    })
      .then(res => res.json())
      .then(
        (result) => {
          setIsLoaded(true);
          setItems(result.data);
        },
        (error) => {
          setIsLoaded(true);
          setHasError(error);
        }
      )
  }, []);

  const fetchStudents = async (id) => {
    fetch(`${process.env.API_URL}/students/getByCourseId/${id}`, {
      headers: new Headers({
        'content-type': 'application/json',
        Authorization: tokenStr
      }),
    })
      .then(res => res.json())
      .then(
        (result) => {
          setIsLoaded(true);
          setStudents(result.data); // Assuming this is where you want to set the students
        },
        (error) => {
          setIsLoaded(true);
          setHasError(error);
        }
      )
  }

  return (
    <div className="col-12">
      <h4>Kurslarım</h4>

      {
        items.map((course, index) => {
          return (
            <div className="card" key={index}>
              <div className="card-body">
                <div className="post">
                  <div className="user-block">
                    <img
                      className="img-circle img-bordered-sm"
                      src="../../assets/img/post/course.png"
                      alt="user image"
                    />
                    <span className="username">
                      <a href="#">{course.name}</a>
                    </span>
                    <span className="description">{new Date(course.startCourseTime).toLocaleDateString("tr-TR")} - {new Date(course.finishCourseTime).toLocaleDateString("tr-TR")}</span>
                  </div>
                  {/* /.user-block */}
                  <p>
                    {course.description}
                  </p>
                  <p>
                    <a href="#" className="link-black text-sm">
                    <i class="fas fa-lira-sign mr-1"></i> Fiyat:{ course.price}
                    </a>
                  </p>
                </div>

              </div>
              <div className="card-footer">
              <p>
                    <a  className="text-bg" onClick={()=>handleToggle(index,course.id)}>
                      <i className="fas fa-users mr-1" /> Kayıtlı öğrenciler
                    </a>
                  </p>
              <div className={index==visibleItem?"" :"collapse"}>
                <div className="card card-body">
                {
                  isLoaded ? <table  className="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>İsim</th>
                        <th>Soyad</th>
                        <th>Kayıt Tarihi</th>
                      </tr>
                    </thead>
                    <tbody>
                      {
                        students!==undefined?
                        students.map((student, index) => {
                          return (
                            <tr key={index}>
                              <td><p style={{ whiteSpace: "nowrap" }}>{student.firstName}</p></td>
                              <td><p style={{ whiteSpace: "nowrap" }}>{student.lastName}</p></td>
                              <td><p style={{ whiteSpace: "nowrap" }}>{ new Date(course.createdDate).toLocaleDateString("tr-TR")}</p></td>
                            </tr>
                          )
                        })
                        : <div className="container">Kayıtlı öğrenci bulunamadı</div>
                      }

                    </tbody>
                  </table>
                    : <h4> Öğrenci bulunmadı</h4>
                }
                </div>
              </div>
              </div>
            </div>
          )
        })
      }



    </div>

  )
}
