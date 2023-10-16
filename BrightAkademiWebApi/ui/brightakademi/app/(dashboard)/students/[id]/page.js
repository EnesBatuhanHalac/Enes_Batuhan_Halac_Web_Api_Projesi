"use client"
import { info } from 'autoprefixer';
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';
import { Modal, Button } from "react-bootstrap";    
import Link from 'next/link';
import { useParams } from 'next/navigation';
export default function Home() {

  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [item, setItem] = useState({ });
  const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access')).token;
  const params = useParams()



  const [inputField, setInputField] = useState({
    name: '',
    url: '',
    description: ''
  })

  const notify = (message, type) => {
    switch (type) {
      case "success":
        toast.success(message);
        break;
      case "error":
        toast.error(message);
        break;
      case "info":
        toast.info(message)
        break;
      default:
        toast(message);
        break;
    }
  }

  useEffect(() => {

    fetch(`${process.env.API_URL}/courses/studentCourses/${params.id}`,{
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
          setError(error);
        }
      )
  }, [item])

  const handleCloseCreateModal = () => setIsCreateModalOpen(false)
  const handleOpenCreateModal = () => setIsCreateModalOpen(true)
  const handleOpenDeleteModal = () => setIsDeleteModalOpen(true)
  const handleCloseDeleteModal = () => setIsDeleteModalOpen(false)
  const handleOpenUpdateModal = () => setIsUpdateModalOpen(true)
  const handleCloseUpdateModal = () => setIsUpdateModalOpen(false)
  const handleItem2Delete = (item) => {
    item.isDeleted = true
    setItem(item)
    handleOpenDeleteModal()
  }
  const handleItem2Update = (item) => {
    setItem(item)
    handleOpenUpdateModal()
  }



  const handleSubmit = () => {
    var obj = JSON.stringify(inputField);
    fetch(`${process.env.API_URL}/courses`,
      {
        method: 'POST',
        body: obj,
        headers: new Headers({
          'content-type': 'application/json',
            Authorization: tokenStr
        }),      })
      .then(res => res.json())
      .then(
        (result) => {
          if (result.errors == null)
            notify("Kurs Kaydedildi");
          else
            notify(result.title, "error");
        },
        (error) => {
          notify(error.title, "error")

          setIsLoaded(true);
        }
      ).finally(
        handleCloseCreateModal()
      )
    setIsLoaded(false)
  }
  const handleUpdate = () => {
    var obj = JSON.stringify(item);
    fetch(`${process.env.API_URL}/courses`,
      {
        method: 'PUT',
        body: obj,
        headers: new Headers({
          'content-type': 'application/json',
            Authorization: tokenStr
        }),      })
      .then(res => res.json())
      .then(
        (result) => {
          if (result.errors == null)
            notify("Kurs Kaydedildi");
          else
            notify(result.title, "error");
        },
        (error) => {
          notify(error.title, "error")
          setIsLoaded(true);
        }
      ).finally(f => {
        handleCloseUpdateModal()
        setItem({ id: -1, name: "", url: "", description: "" })
      }
      )
    setIsLoaded(false)
  }

  const handleDelete = () => {
    var obj = JSON.stringify(item)
    fetch(`${process.env.API_URL}/courses`,
      {
        method: 'PUT',
        body: obj,
        headers: new Headers({
          'content-type': 'application/json',
            Authorization: tokenStr
        }),      })
      .then(res => res.json())
      .then(
        (result) => {
          if (result.errors == null)
            notify("Kurs Silindi");
          else
            notify(result.title, "error");
        },
        (error) => {
          notify(error.title, "error")
        }
      ).finally(f => {
        setItem({ id: -1, name: "", url: "", description: "" })
        handleCloseDeleteModal()
      })
    setIsLoaded(false)
  }

  return (
    <section className="content">
      <div className="container-fluid">
        <div className="row">
          <div className="col-12">
            {/* Delete Modal */}
            <Modal show={isDeleteModalOpen} onHide={handleCloseDeleteModal}>
              <Modal.Header >
                <Modal.Title><h5>Kurs silinecek,  onaylıyor musunuz?</h5></Modal.Title>
              </Modal.Header>
              <Modal.Footer>
                <Button variant="secondary" onClick={handleCloseDeleteModal}>
                  Kapat
                </Button>
                <Button variant="danger" onClick={handleDelete}>
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
                    courses
                  </h3>
                  <button className='btn btn-sm btn-primary' onClick={handleOpenCreateModal}>Ekle</button>
                </div>
              </div>
              {/* /.card-header */}
              <div className="card-body">
                {
                  isLoaded? <table id="example2" className="table table-bordered table-hover">
                  <thead>
                    <tr>
                      <th>İsim</th>
                      <th>Toplam Süre</th>
                      <th>Ay</th>
                      <th>Başlangıç Tarihi</th>
                      <th>Bitiş Tarihi</th>
                      <th>Fiyat</th>
                      <th>Aktiflik</th>
                      <th>Düzenle</th>
                      <th>Sil</th>
                    </tr>
                  </thead>
                  <tbody>
                    {
                      items.map((course, index) => {
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
                            <td>
                                <Link className='text-warning'
                                  href={`/courses/${course.id}`}
                                ><i className="fas fa-edit"></i></Link>
                              </td>
                              <td>
                                <a
                                  onClick={() => handleItem2Delete(course)}
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
                      <th>Toplam Süre</th>
                      <th>Ay</th>
                      <th>Başlangıç Tarihi</th>
                      <th>Bitiş Tarihi</th>
                      <th>Fiyat</th>
                      <th>Aktiflik</th>
                      <th>Düzenle</th>
                      <th>Sil</th>
                    </tr>
                  </tfoot>
                </table>
                : <h4> Kurs bulunmadı, yeni birtane ekleyin</h4>
                }
                
              </div>
              {/* /.card-body */}
            </div>
          </div>
          {/* /.col */}
        </div>
        {/* /.row */}
      </div>
    </section>


  )
}
