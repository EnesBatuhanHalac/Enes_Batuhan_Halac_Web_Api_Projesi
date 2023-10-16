"use client"
import React, { useEffect, useState } from 'react'
import useTokenExpirationCheck from '@/app/hooks/useTokenExpirationCheck'
import Link from 'next/link';
import { Button, Modal } from 'react-bootstrap';
import { toast } from 'react-toastify';

export default function MyCourses() {
  const [items, setItems] = useState([]);
  const [courses, setCourses] = useState([]);
  const [refresh, setRefresh] = useState(1);
  const [isLoaded, setIsLoaded] = useState(false);
  const [hasError, setHasError] = useState(null);
  const [item, setItem] = useState({ });
  const handleOpenRegisterModal = () => setIsRegisterModalOpen(true)
  const handleCloseRegisterModal = () => setIsRegisterModalOpen(false)
  const [isRegisterModalOpen, setIsRegisterModalOpen] = useState(false);
  const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access')).token;
  useTokenExpirationCheck()

  const handleItem2Register = (item) => {
    setItem(item)
    handleOpenRegisterModal()
  }

  useEffect(() => {
    fetch(`${process.env.API_URL}/courses/mycourses`, {
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
  }, [])

  useEffect(() => {
    fetch(`${process.env.API_URL}/courses/toRegister`, {
      headers: new Headers({
        'content-type': 'application/json',
        Authorization: tokenStr
      }),
    })
      .then(res => res.json())
      .then(
        (result) => {
          setIsLoaded(true);
          setCourses(result.data);
        },
        (error) => {
          setIsLoaded(true);
          setHasError(error);
        }
      )
  }, [])

  const handleRegister = () => {

    fetch(`${process.env.API_URL}/courses/register/${item.id}`,
      {
        method: 'GET',
        headers: new Headers({
          'content-type': 'application/json',
          Authorization: tokenStr
        }),
      })
      .then((res) => {
        if (!res.ok) { throw new Error("unauthorized") }
        return res.json();
      })
      .then(
        (result) => {
          if (result.errors == null)
            toast("Kaydolundu");
          else
            toast.error(result.title);
        }).catch(e => {
          toast.error("Yetkiniz yok")
         setHasError(true)
        }).finally(f => {
          setItem({})
          handleCloseRegisterModal()
          setIsLoaded(true)
        })
        setRefresh(refresh+1)
  }
  return (
    <>
      <div className="col-12">
        <h4>Derslerim</h4>

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
                        <i className="fas fa-link mr-1" /> Demo File 1 v2
                      </a>
                    </p>
                  </div>
                </div>
              </div>
            )
          })
        }



      </div>
      <div className="row">
        <div className="col-12">
          {/* Register Modal */}
          <Modal show={isRegisterModalOpen} onHide={handleCloseRegisterModal}>
            <Modal.Header >
              <Modal.Title><h5>Kursa kaydolmak istiyor musunuz?</h5></Modal.Title>
            </Modal.Header>
            <Modal.Footer>
              <Button variant="secondary" onClick={handleCloseRegisterModal}>
                Kapat
              </Button>
              <Button variant="danger" onClick={handleRegister}>
                Onayla
              </Button>
            </Modal.Footer>
          </Modal>
          <div className="modal show" >
            <div className="modal-dialog"  >
              <div className="modal-content">
                <div className="modal-header">
                  <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div className="modal-footer justify-content-between">
                  <button type="button" className="btn btn-default" data-dismiss="modal">Kapat</button>
                  <button type="button" className="btn btn-danger">Onayla</button>
                </div>
              </div>
            </div>
          </div>


          <div className="card">
            <div className="card-header " >
              <div className='d-flex justify-content-between'>
                <h3 className="card-title">
                  Kaydolabileceğim Dersler
                </h3>
              </div>
            </div>
            {/* /.card-header */}
            <div className="card-body">
              {
                isLoaded ? <table id="example2" className="table table-bordered table-hover">
                  <thead>
                    <tr>
                      <th>İsim</th>
                      <th>Toplam Süre</th>
                      <th>Ay</th>
                      <th>Başlangıç Tarihi</th>
                      <th>Bitiş Tarihi</th>
                      <th>Fiyat</th>
                      <th>Kaydol</th>
                    </tr>
                  </thead>
                  <tbody>
                    {
                      courses.map((course, index) => {
                        return (
                          <tr key={index}>
                            <td><p style={{ whiteSpace: "nowrap" }}>{course.name}</p></td>
                            <td>{course.totalCourseHours}</td>
                            <td>{course.howManyMonths}</td>
                            <td>{new Date(course.startCourseTime).toLocaleDateString("tr-TR")}</td>
                            <td>{new Date(course.finishCourseTime).toLocaleDateString("tr-TR")}</td>
                            <td>{course.price}</td>
                            <td>
                              <a
                                onClick={() => handleItem2Register(course)}
                                className='text-sucess' ><i className="fas fa-plus"></i></a>
                            </td>
                          </tr>
                        )
                      })
                    }

                  </tbody>
                </table>
                  : <h4> Ders bulunmadı</h4>
              }

            </div>
            {/* /.card-body */}
          </div>
        </div>
        {/* /.col */}
      </div>
    </>
  )
}
