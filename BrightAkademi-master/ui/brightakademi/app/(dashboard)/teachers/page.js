"use client"
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';
import { Modal, Button } from "react-bootstrap";
import { useRouter } from 'next/navigation';

export default function Home() {

  const [refresh, setRefresh] = useState(1);
  const [hasError, setHasError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);
  const [isCreateModalOpen, setIsCreateModalOpen] = useState(false);
  const [isUpdateModalOpen, setIsUpdateModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [item, setItem] = useState({ });
  const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access'))?.token;
  const router = useRouter()


  const [inputField, setInputField] = useState({
    firstName: '',
    lastName: '',
    profession: '',
    experience: '',
    educationInfo: '',
    comment: '',
    isActive: false,
  })


  const inputsHandler = (e) => {
    const newValue = e.target.type === 'checkbox' ? e.target.checked : e.target.value;
    setInputField({ ...inputField, [e.target.name]: newValue })  }

  const itemHandler = (e) => {
    const newValue = e.target.type === 'checkbox' ? e.target.checked : e.target.value;
    setItem({ ...item, [e.target.name]: newValue })
  }
  
  useEffect(() => {
    fetch(`${process.env.API_URL}/teachers`, {
      headers: new Headers({
        'content-type': 'application/json',
        Authorization: tokenStr
      }),
    }).then((res)=>{
      if(!res.ok){ throw new Error("unauthorized")}
      return res.json();
    }).then(
        (result) => {
          setIsLoaded(true);
          setItems(result.data);
        },
        (error) => {
          toast.error("Erişiminiz bulunmamakta")
          router.push("/dashboard")
          setHasError(true);
        }
      )
  }, [refresh])


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
    fetch(`${process.env.API_URL}/teachers`,
      {
        method: 'POST',
        body: obj,
        headers: new Headers({
          'content-type': 'application/json',
          Authorization: tokenStr
        }),
      }).then((res) => {
        if (!res.ok) { throw new Error("unauthorized") }
        return res.json();
      })
      .then(
        (result) => {
          if (result.errors == null)
            toast("Öğretmen Kaydedildi");
          else
            toast.error(result.title);
        },
      ).catch(e => {
        toast.error("Yetkiniz yok")
       setHasError(true)
      })
      .finally(() => {
        handleCloseCreateModal()
        setIsLoaded(true)
      })
      setRefresh(refresh+1)
  }
  const handleUpdate = () => {
    var obj = JSON.stringify(item);
    fetch(`${process.env.API_URL}/teachers`,
      {
        method: 'PUT',
        body: obj,
        headers: new Headers({
          'content-type': 'application/json',
          Authorization: tokenStr
        }),
      })
      .then((res) => {
        return res.json();
      })
      .then(
        (result) => {
          if (result.errors == null)
            toast("Öğretmen Kaydedildi");
          else
            toast.error(result.title);
        }).catch((e) => {
          toast.error("Yetkiniz yok")
         setHasError(true)

        })
      .finally(f => {
        handleCloseUpdateModal()
        setItem({})
        setIsLoaded(true);
      }
      )
      setRefresh(refresh+1)
  }

  const handleDelete = () => {
    var obj = JSON.stringify(item)
    fetch(`${process.env.API_URL}/teachers`,
      {
        method: 'PUT',
        body: obj,
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
            notify("Öğretmen Silindi");
          else
            notify(result.title, "error");
        }).catch(e => {
          toast.error("Yetkiniz yok")
         setHasError(true)
        }).finally(f => {
          setItem({})
          handleCloseDeleteModal()
          setIsLoaded(true)
        })
        setRefresh(refresh+1)
  }

  return (
    <section className="content">
      <div className="container-fluid">
        <div className="row">
          <div className="col-12">
            {/* Create Modal */}
            <Modal show={isCreateModalOpen} onHide={handleOpenCreateModal}>
              <Modal.Header >
                <Modal.Title>Yeni Öğretmen</Modal.Title>
              </Modal.Header>
              <Modal.Body>
              <form>
                  <div className="card-body">
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Ad</label>
                      <input
                        type="text"
                        name='firstName'
                        onChange={inputsHandler}
                        value={inputField.firstName}
                        className="form-control"
                        
                        placeholder="İsim"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Soyad</label>
                      <input
                        type="text"
                        name='lastName'
                        onChange={inputsHandler}
                        value={inputField.lastName}
                        className="form-control"
                        
                        placeholder="Soyad"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Alan</label>
                      <input
                        type="text"
                        name='profession'
                        onChange={inputsHandler}
                        value={inputField.profession}
                        className="form-control"
                        
                        placeholder="Alan"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Deneyim</label>
                      <input
                        type="text"
                        name='experience'
                        onChange={inputsHandler}
                        value={inputField.experience}
                        className="form-control"
                        
                        placeholder="Deneyim"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Eğitim</label>
                      <input
                        type="text"
                        name='educationInfo'
                        onChange={inputsHandler}
                        value={inputField.educationInfo}
                        className="form-control"
                        
                        placeholder="Eğitim"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Yorum</label>
                      <textarea
                        type="text"
                        name='comment'
                        onChange={inputsHandler}
                        value={inputField.comment}
                        className="form-control"
                        
                        placeholder="Enter email"
                      />
                    </div>
                    <div className="form-check">
                      <input
                        type="checkbox"
                        name='isActive'
                        value={inputField.isActive}
                        onChange={inputsHandler}
                        className="form-check-input"
                        placeholder="Aktif"
                        
                        readOnly
                      />
                      <label className="form-check-label">
                        Aktif
                      </label>
                    </div>

                  </div>

                </form>
              </Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" onClick={handleCloseCreateModal}>
                  Kapat
                </Button>
                <Button variant="primary" onClick={handleSubmit}>
                  Ekle
                </Button>
              </Modal.Footer>
            </Modal>
            {/* Update Modal */}
            <Modal show={isUpdateModalOpen} onHide={handleOpenUpdateModal}>
              <Modal.Header >
                <Modal.Title>Öğretmen Güncelle</Modal.Title>
              </Modal.Header>
              <Modal.Body>
                <form>
                  <div className="card-body">
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Ad</label>
                      <input
                        type="text"
                        name='firstName'
                        onChange={itemHandler}
                        value={item.firstName}
                        className="form-control"
                        placeholder="İsim"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Soyad</label>
                      <input
                        type="text"
                        name='lastName'
                        onChange={itemHandler}
                        value={item.lastName}
                        className="form-control"
                        
                        placeholder="Soyad"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Alan</label>
                      <input
                        type="text"
                        name='profession'
                        onChange={itemHandler}
                        value={item.profession}
                        className="form-control"
                        
                        placeholder="Alan"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Deneyim</label>
                      <input
                        type="text"
                        name='experience'
                        onChange={itemHandler}
                        value={item.experience}
                        className="form-control"
                        
                        placeholder="Deneyim"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Eğitim</label>
                      <input
                        type="text"
                        name='educationInfo'
                        onChange={itemHandler}
                        value={item.educationInfo}
                        className="form-control"
                        
                        placeholder="Eğitim"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Yorum</label>
                      <textarea
                        type="text"
                        name='comment'
                        onChange={itemHandler}
                        value={item.comment}
                        className="form-control"
                        
                        placeholder="Enter email"
                      />
                    </div>
                    <div className="form-check">
                      <input
                        type="checkbox"
                        name='isActive'
                        value={item.isActive}
                        onChange={itemHandler}
                        className="form-check-input"
                        placeholder="Aktif"
                        checked={item.isActive}
                      />
                      <label className="form-check-label">
                        Aktif
                      </label>
                    </div>

                  </div>

                </form>
              </Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" onClick={handleCloseUpdateModal}>
                  Kapat
                </Button>
                <Button variant="primary" onClick={handleUpdate}>
                  Güncelle
                </Button>
              </Modal.Footer>
            </Modal>
            {/* Delete Modal */}
            <Modal show={isDeleteModalOpen} onHide={handleCloseDeleteModal}>
              <Modal.Header >
                <Modal.Title><h5>Öğretmen silinecek,  onaylıyor musunuz?</h5></Modal.Title>
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
                    teachers
                  </h3>
                  <button className='btn btn-sm btn-primary' onClick={handleOpenCreateModal}>Ekle</button>
                </div>
              </div>
              {/* /.card-header */}
              <div className="card-body">
                {
                  isLoaded? <table  className="table table-bordered table-hover">
                  <thead>
                    <tr>
                      <th>Ad</th>
                      <th>Soyad</th>
                      <th>Alan</th>
                      <th>Deneyim</th>
                      <th>Aktiflik</th>
                      <th>Düzenle</th>
                      <th>Sil</th>
                    </tr>
                  </thead>
                  <tbody>
                    {
                      items.map((teacher, index) => {
                        return (
                          <tr key={index}>
                            <td><p style={{ whiteSpace: "nowrap" }}>{teacher.firstName}</p></td>
                            <td><p style={{ whiteSpace: "nowrap" }}>{teacher.lastName}</p></td>
                            <td><p style={{ whiteSpace: "nowrap" }}>{teacher.profession}</p></td>
                            <td><p style={{ whiteSpace: "nowrap" }}>{teacher.experience}</p></td>
                            <td>
                              <div className="form-group">
                                <div className="custom-control custom-switch custom-switch-off-danger custom-switch-on-success">
                                  <input
                                    type="checkbox"
                                    className="custom-control-input"
                                    
                                    checked={teacher.isActive}
                                    readOnly
                                  />
                                  <label className="custom-control-label" htmlFor="customSwitch3">

                                  </label>
                                </div>
                              </div>
                            </td>
                            <td>
                              <button className='btn btn-warning w-100 h-100 m-0'
                                onClick={() => handleItem2Update(teacher)}
                              >Düzenle</button>
                            </td>
                            <td>
                              <button
                                onClick={() => handleItem2Delete(teacher)}
                                className='btn btn-danger w-100 h-100 m-0' >Sil</button>
                            </td>
                          </tr>
                        )
                      })
                    }

                  </tbody>
                  <tfoot>
                    <tr>
                    <th>Ad</th>
                      <th>Soyad</th>
                      <th>Alan</th>
                      <th>Deneyim</th>
                      <th>Aktiflik</th>
                      <th>Düzenle</th>
                      <th>Sil</th>
                    </tr>
                  </tfoot>
                </table>
                : <h4> Öğretmen bulunmadı, yeni birtane ekleyin</h4>
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
