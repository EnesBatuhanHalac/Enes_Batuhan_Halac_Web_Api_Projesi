"use client"
import { info } from 'autoprefixer';
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';
import { Modal, Button } from "react-bootstrap";
import hasAccess from '@/app/hooks/hasAccess'
export default function Home() {

  const [refresh, setRefresh] = useState(1);
  const [hasError, setHasError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);
  const [isCreateModalOpen, setIsCreateModalOpen] = useState(false);
  const [isUpdateModalOpen, setIsUpdateModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [item, setItem] = useState({});
  const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access')).token;


  const [inputField, setInputField] = useState({
    name: '',
    phoneNumber: '',
    email:'',
    isActive:false,
    address:'',
    about: '',
    faq: '',
    description: ''
  })
  const resetInputField =()=>{
    setInputField({
        name: '',
        phoneNumber: '',
        email:'',
        isActive:false,
        address:'',
        about: '',
        faq: '',
        description: ''
    })
  }


  const inputsHandler = (e) => {
    setInputField({ ...inputField, [e.target.name]: e.target.value })
  }
  const itemHandler = (e) => {
    const newValue = e.target.type === 'checkbox' ? e.target.checked : e.target.value;
    setItem({ ...item, [e.target.name]: newValue })
  }
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
    fetch(`${process.env.API_URL}/companies`, {
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
  }, [refresh,setItem, setInputField])

  const handleCloseCreateModal = () => setIsCreateModalOpen(false)
  const handleOpenCreateModal = () => setIsCreateModalOpen(true)
  const handleOpenDeleteModal = () =>setIsDeleteModalOpen(true)
  const handleCloseDeleteModal = () => setIsDeleteModalOpen(false)
  const handleOpenUpdateModal = () => setIsUpdateModalOpen(true)
  const handleCloseUpdateModal = ()=> setIsUpdateModalOpen(false)
  const handleItem2Delete = (item) => {
    item.IsDeleted = true
    setItem(item)
    handleOpenDeleteModal()
  }
  const handleItem2Update = (item) => {
    setItem(item)
    console.log(item)
    handleOpenUpdateModal()
  }

  const handleSubmit = () => {
    var obj = JSON.stringify(inputField);
    fetch(`${process.env.API_URL}/companies`,
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
            toast("Şirket Kaydedildi");
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
        setInputField({})

      })
      setRefresh(refresh+1)
  }
  const handleUpdate = () => {
    var obj = JSON.stringify(item);
    fetch(`${process.env.API_URL}/companies`,
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
            toast("Şirket Kaydedildi");
          else
            toast.error(result.title);
        }).catch(() => {
          if (!hasAccess()) {
            toast.error("Yetkiniz yok")
            setHasError(true)
          }
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
    fetch(`${process.env.API_URL}/companies`,
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
            notify("Şirket Silindi");
          else
            notify(result.title, "error");
        }).catch(e => {
          if (!hasAccess()) {
            toast.error("Yetkiniz yok")
            setHasError(true)
          }
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
                <Modal.Title>Yeni Kategori</Modal.Title>
              </Modal.Header>
              <Modal.Body>
              <form onSubmit={(e) => handleSubmit(e)}>
                  <div className="card-body">
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">İsim</label>
                      <input
                        type="text"
                        onChange={(inputsHandler)}
                        name='name'
                        value={inputField.name}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="İsim"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Telefon</label>
                      <input
                        type="text"
                        onChange={inputsHandler}
                        name='phoneNumber'
                        value={inputField.phoneNumber}
                        className="form-control"
                        placeholder="Telefon"

                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Email</label>
                      <input
                        type="text"
                        onChange={inputsHandler}
                        name='email'
                        value={inputField.email}
                        className="form-control"
                        placeholder='Email'
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Adres</label>
                      <input
                        type="text"
                        onChange={(inputsHandler)}
                        name='address'
                        value={inputField.address}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Adres"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Hakkında</label>
                      <input
                        type="text" 
                        onChange={(inputsHandler)}
                        name='about'
                        value={inputField.about}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Hakkında"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Faq</label>
                      <input
                        type="text" 
                        onChange={(inputsHandler)}
                        name='faq'
                        value={inputField.faq}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Faq"
                      />
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
                <Modal.Title>Firma Güncelle</Modal.Title>
              </Modal.Header>
              <Modal.Body>
              <form onSubmit={(e) => handleUpdate(e)}>
                  <div className="card-body">
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">İsim</label>
                      <input
                        type="text"
                        onChange={(itemHandler)}
                        name='name'
                        value={item.name}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="İsim"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Telefon</label>
                      <input
                        type="text"
                        onChange={itemHandler}
                        name='phoneNumber'
                        value={item.phoneNumber}
                        className="form-control"
                        placeholder="Telefon"

                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Email</label>
                      <input
                        type="text"
                        onChange={itemHandler}
                        name='email'
                        value={item.email}
                        className="form-control"
                        placeholder='Email'
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Adres</label>
                      <input
                        type="text"
                        onChange={(itemHandler)}
                        name='address'
                        value={item.address}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Adres"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Hakkında</label>
                      <input
                        type="text" 
                        onChange={(itemHandler)}
                        name='about'
                        value={item.about}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Hakkında"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Faq</label>
                      <input
                        type="text" 
                        onChange={(itemHandler)}
                        name='faq'
                        value={item.faq}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Faq"
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

                        id="customSwitch3"
                        checked={item.isActive}
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
                <Modal.Title><h5>Kategori silinecek,  onaylıyor musunuz?</h5></Modal.Title>
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
                  Companies
                  </h3>
                  <button className='btn btn-sm btn-primary' onClick={handleOpenCreateModal}>Ekle</button>
                </div>
              </div>
              {/* /.card-header */}
              <div className="card-body">
                <table id="example2" className="table table-bordered table-hover">
                  <thead>
                    <tr>
                      <th>İsim</th>
                      <th>Telefon</th>
                      <th>Email</th>
                      <th>Aktif</th>
                      <th>Düzenle</th>
                      <th>Sil</th>
                    </tr>
                  </thead>
                  <tbody>
                    {
                      items.map((company, index) => {
                        return (
                          <tr key={index}>
                            <td><p style={{ whiteSpace: "nowrap" }}>{company.name}</p></td>
                            <td><p>{company.phoneNumber}</p></td>
                            <td><p>{company.email}</p></td>
                            <td>
                              <div className="form-group">
                                <div className="custom-control custom-switch custom-switch-off-danger custom-switch-on-success">
                                  <input
                                    type="checkbox"
                                    className="custom-control-input"
                                    id="customSwitch3"
                                    checked={company.isActive}
                                    readOnly
                                  />
                                  <label className="custom-control-label" htmlFor="customSwitch3">

                                  </label>
                                </div>
                              </div>
                            </td>
                            <td>
                                <a className='text-warning'
                                  onClick={() => handleItem2Update(company)}
                                ><i className="fas fa-edit"></i></a>
                              </td>
                              <td>
                                <a
                                  onClick={() => handleItem2Delete(company)}
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
                      <th>Telefon</th>
                      <th>Email</th>
                      <th>Aktif</th>
                      <th>Düzenle</th>
                      <th>Sil</th>
                    </tr>
                  </tfoot>
                </table>
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
