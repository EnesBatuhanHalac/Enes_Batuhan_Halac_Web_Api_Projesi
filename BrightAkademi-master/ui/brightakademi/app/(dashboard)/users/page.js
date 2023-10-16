"use client"
import { info } from 'autoprefixer';
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';
import { Modal, Button } from "react-bootstrap";
import { useRouter } from 'next/navigation';

export default function Home() {

  const [refresh, setRefresh] = useState(1);
  const [hasError, setHasError] = useState(null);
  const [isLoaded, setIsLoaded] = useState(false);
  const [items, setItems] = useState([]);
  const [roles, setRoles] = useState([]);
  const [isCreateModalOpen, setIsCreateModalOpen] = useState(false);
  const [isUpdateModalOpen, setIsUpdateModalOpen] = useState(false);
  const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
  const [isPermModalOpen, setIsPermModalOpen] = useState(false);
  const [item, setItem] = useState({});
  const [roleId, setRoleId] = useState(-1);
  const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access')).token;
  const router = useRouter()

  const [inputField, setInputField] = useState({
    username: '',
    password: '',
    isActive: false
  })


  const inputsHandler = (e) => {
    const newValue = e.target.type === 'checkbox' ? e.target.checked : e.target.value;
    setInputField({ ...inputField, [e.target.name]: newValue })
  }
  const itemHandler = (e) => {
    const newValue = e.target.type === 'checkbox' ? e.target.checked : e.target.value;
    setItem({ ...item, [e.target.name]: newValue })
  }

  useEffect(() => {
    fetch(`${process.env.API_URL}/users`, {
      headers: new Headers({
        'content-type': 'application/json',
        Authorization: tokenStr
      }),
    }).then((res) => {
      if (!res.ok) { throw new Error("unauthorized") }
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

  useEffect(() => {
    fetch(`${process.env.API_URL}/auth/roles`, {
      headers: new Headers({
        'content-type': 'application/json',
        Authorization: tokenStr
      }),
    }).then(res => res.json())
      .then(
        (result) => {
          setRoles(result.data);
        },
      )
  }, [])


  const handleCloseCreateModal = () => setIsCreateModalOpen(false)
  const handleOpenCreateModal = () => setIsCreateModalOpen(true)
  const handleOpenDeleteModal = () => setIsDeleteModalOpen(true)
  const handleCloseDeleteModal = () => setIsDeleteModalOpen(false)
  const handleOpenUpdateModal = () => setIsUpdateModalOpen(true)
  const handleCloseUpdateModal = () => setIsUpdateModalOpen(false)
  const handleOpenPermModal = () => setIsPermModalOpen(true)
  const handleClosePermModal = () => setIsPermModalOpen(false)
  const handleItem2Delete = (item) => {
    item.isDeleted = true
    setItem(item)
    handleOpenDeleteModal()
  }
  const handleItem2Update = (item) => {
    setItem(item)
    handleOpenUpdateModal()
  }
  const handleItem2Perm = (item) => {
    setItem(item)
    handleOpenPermModal()
  }



  const handleSubmit = () => {
    var obj = JSON.stringify(inputField);
    fetch(`${process.env.API_URL}/users`,
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
            toast("Kullanıcı Kaydedildi");
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
    setRefresh(refresh + 1)
  }
  const handleUpdate = () => {
    var obj = JSON.stringify(item);
    fetch(`${process.env.API_URL}/users`,
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
            toast("Kullanıcı Kaydedildi");
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
    setRefresh(refresh + 1)
  }

  const handleDelete = () => {
    var obj = JSON.stringify(item)
    fetch(`${process.env.API_URL}/users`,
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
            notify("Kullanıcı Silindi");
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
    setRefresh(refresh + 1)
  }

  const handlePerm = () => {
    var obj = JSON.stringify({
      userId: item.id,
      roleId: roleId
    })
    fetch(`${process.env.API_URL}/auth/changeRole`, {
      method: 'PUT',
      body: obj,
      headers: new Headers({
        'content-type': 'application/json',
        Authorization: tokenStr
      },
      ),
    }).then((res) => { return res.json() })
      .then(
        (result) => {
          toast.success("Rol Değiştirildi")
        },
      ).finally(handleClosePermModal())
  }


  return (
    <section className="content">
      <div className="container-fluid">
        <div className="row">
          <div className="col-12">
            {/* Create Modal */}
            <Modal show={isCreateModalOpen} onHide={handleOpenCreateModal}>
              <Modal.Header >
                <Modal.Title>Yeni Kullanıcı</Modal.Title>
              </Modal.Header>
              <Modal.Body>
                <form onSubmit={(e) => handleSubmit(e)}>
                  <div className="card-body">
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Kullanıcı adı</label>
                      <input
                        type="text"
                        onChange={(inputsHandler)}
                        name='username'
                        value={inputField.username}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Kullanıcı adı"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Şifre</label>
                      <input
                        type="text"
                        onChange={inputsHandler}
                        name='password'
                        value={inputField.password}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Şifre"
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
                <Modal.Title>Kullanıcı Güncelle</Modal.Title>
              </Modal.Header>
              <Modal.Body>
                <form>
                  <div className="card-body">
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1"> Ad</label>
                      <input
                        type="text"
                        name='firstname'
                        onChange={itemHandler}
                        value={item.firstname}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Kullanıcı adı"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Soyad</label>
                      <input
                        type="text"
                        name='lastname'
                        onChange={itemHandler}
                        value={item.lastname}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Kullanıcı adı"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Kullanıcı adı</label>
                      <input
                        type="text"
                        name='username'
                        onChange={itemHandler}
                        value={item.username}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Kullanıcı adı"
                      />
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputEmail1">Şifre</label>
                      <input
                        type="password"
                        name='password'
                        onChange={itemHandler}
                        value={item.password}
                        className="form-control"
                        id="exampleInputEmail1"
                        placeholder="Şifre"
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
            {/* Permisson Modal */}
            <Modal show={isPermModalOpen} onHide={handleOpenPermModal}>
              <Modal.Header >
                <Modal.Title>Rol Güncelle</Modal.Title>
              </Modal.Header>
              <Modal.Body>
                <form>
                  <div className="card-body">
                    <div className="form-group">
                      <label>İzinler</label>
                      <select className="select2" onChange={(e) => { setRoleId(e.target.value) }} data-placeholder="Rol seç" style={{ width: "100%" }}>
                        <option  disabled value={-1} >Seçiniz</option>
                        {
                          roles.map((rol, index) => {
                            return (
                              <option key={index} value={rol.id}>{rol.name}</option>
                            )
                          })
                        }
                      </select>
                    </div>

                  </div>

                </form>
              </Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" onClick={handleClosePermModal}>
                  Kapat
                </Button>
                <Button variant="primary" onClick={handlePerm}>
                  Güncelle
                </Button>
              </Modal.Footer>
            </Modal>
            {/* Delete Modal */}
            <Modal show={isDeleteModalOpen} onHide={handleCloseDeleteModal}>
              <Modal.Header >
                <Modal.Title><h5>Kullanıcı silinecek,  onaylıyor musunuz?</h5></Modal.Title>
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
                    users
                  </h3>
                  <button className='btn btn-sm btn-primary' onClick={handleOpenCreateModal}>Ekle</button>
                </div>
              </div>
              {/* /.card-header */}
              <div className="card-body">
                {
                  isLoaded ? <table id="example2" className="table table-bordered table-hover">
                    <thead>
                      <tr>
                        <th>Kullanıcı adı</th>
                        <th>Ad</th>
                        <th>Soyad</th>
                        <th>Şifre</th>
                        <th>Aktiflik</th>
                        <th>Düzenle</th>
                        <th>Rol değitir</th>
                        <th>Sil</th>
                      </tr>
                    </thead>
                    <tbody>
                      {
                        items.map((user, index) => {
                          return (
                            <tr key={index}>
                               <td><p style={{ whiteSpace: "nowrap" }}>{user.firstname}</p></td>
                              <td><p style={{ whiteSpace: "nowrap" }}>{user.lastname}</p></td>
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
                              <td>
                                <a className='text-warning'
                                  onClick={() => handleItem2Update(user)}
                                ><i className="fas fa-edit"></i></a>
                              </td>
                              <td>
                                <a className='text-warning'
                                  onClick={() => handleItem2Perm(user)}
                                ><i className="fas fa-key"></i></a>
                              </td>
                              <td>
                                <a
                                  onClick={() => handleItem2Delete(user)}
                                  className='text-danger' ><i className="fas fa-trash"></i></a>
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
                        <th>Kullanıcı adı</th>
                        <th>Şifre</th>
                        <th>Aktiflik</th>
                        <th>Düzenle</th>
                        <th>Rol ata</th>
                        <th>Sil</th>
                      </tr>
                    </tfoot>
                  </table>
                    : <h4> Kullanıcı bulunmadı, yeni birtane ekleyin</h4>
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
