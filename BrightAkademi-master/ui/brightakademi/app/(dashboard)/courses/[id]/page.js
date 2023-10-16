"use client"
import Image from 'next/image'
import { useEffect, useState } from 'react'
import { toast } from 'react-toastify';
import { useParams } from 'next/navigation'

export default function Home() {
    const [item, setItem] = useState({})
    const [categories, setCategories] = useState([])
    const [levels, setLevels] = useState([])
    const [companies, setCompanies] = useState([])
    const [teachers, setTeachers] = useState([])
    const [isLoaded, setIsLoaded] = useState(false);
    const tokenStr = 'Bearer' + ' ' + JSON.parse(localStorage.getItem('access')).token;
    const params = useParams()

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
        fetch(`${process.env.API_URL}/courses/${params.id}`)
            .then(res => res.json())
            .then(
                (result) => {
                    setIsLoaded(true);
                    setItem(result.data);
                },
            )
    }, []
    )
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
    useEffect(() => {
        fetch(`${process.env.API_URL}/teachers`)
            .then(res => res.json())
            .then(
                (result) => {
                    setTeachers(result.data);
                },
            )
    }, []
    )
    useEffect(() => {
        fetch(`${process.env.API_URL}/companies`)
            .then(res => res.json())
            .then(
                (result) => {
                    setCompanies(result.data);
                },
            )
    }, []
    )
    useEffect(() => {
        fetch(`${process.env.API_URL}/levels`)
            .then(res => res.json())
            .then(
                (result) => {
                    setLevels(result.data);
                },
            )
    }, []
    )

  const handleUpdate = (e) => {
    e.preventDefault()
    var obj = JSON.stringify(item);
    fetch(`${process.env.API_URL}/courses`,
    {
        method: 'PUT',
        body: obj,
        headers: new Headers({
          'content-type': 'application/json',
          Authorization: tokenStr
        }),
      })
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
      )
  }


    const itemHandler = (e) => {
        const newValue = e.target.type === 'checkbox' ? e.target.checked : e.target.value;
        setItem({ ...item, [e.target.name]: newValue })
    }

    return (
        <div className="container">
            <div className="card card-primary">
                <div className="card-header">
                    <h3 className="card-title">Kurs Bilgileri</h3>
                </div>
                {!isLoaded ? <p>Yükleniyor</p> :
                    <form>
                        <div className="card-body">
                            <div className="row">
                                <div className="col-sm-6">
                                    <div className="form-group">
                                        <label>İsim</label>
                                        <input type="text"
                                            value={item.name}
                                            onChange={itemHandler}
                                            name='name' className="form-control" placeholder="İsim" />
                                    </div>
                                </div>
                                <div className="col-sm-6">
                                    <div className="form-group">
                                        <label>Toplam saat</label>
                                        <input
                                            type="number"
                                            value={item.totalCourseHours}
                                            onChange={itemHandler}
                                            name='totalCourseHours'
                                            className="form-control"
                                            placeholder="Toplam saat "
                                        />
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-sm-6">
                                    <div className="form-group">
                                        <label>Başlama tarihi</label>
                                        <input type="date"
                                            value={item.startCourseTime}
                                            onChange={itemHandler}
                                            name='startCourseTime' className="form-control" placeholder="Başlangiç tarihi" />
                                    </div>
                                </div>
                                <div className="col-sm-6">
                                    <div className="form-group">
                                        <label>Bitiş tarihi</label>
                                        <input
                                            type="date"
                                            value={item.finishCourseTime}
                                            onChange={itemHandler}
                                            name='finishCourseTime'
                                            className="form-control"
                                            placeholder="Bitiş tarihi "
                                        />
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-sm-6">
                                    <div className="form-group">
                                        <label>Kategori</label>
                                        <select className="form-control select2"
                                            onChange={itemHandler}
                                            style={{ width: "100%" }}>
                                            <option disabled defaultValue={0} >Seçiniz</option>
                                            {
                                                categories.map((item,index)=>{
                                                    return(
                                                        <option key={index} value={item.id} >{item.name}</option>
                                                    )
                                                })
                                            }
                                            
                                        </select>
                                    </div>
                                </div>
                                <div className="col-sm-6">
                                    <div className="form-group">
                                        <label>Teacher</label>
                                        <select
                                            onChange={itemHandler}
                                            className="form-control select2" style={{ width: "100%" }}>
                                           <option disabled defaultValue={0} >Seçiniz</option>
                                            {
                                                teachers.map((item,index)=>{
                                                    return(
                                                        <option key={index} value={item.id} >{item.firstName +" "+item.lastName}</option>
                                                    )
                                                })
                                            }
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div className="row">
                                <div className="col-sm-6">
                                    <div className="form-group">
                                        <label>Level</label>
                                        <select
                                            onChange={itemHandler}
                                            className="form-control select2" style={{ width: "100%" }}>
                                           <option disabled defaultValue={0} >Seçiniz</option>
                                            {
                                                levels.map((item,index)=>{
                                                    return(
                                                        <option key={index} value={item.id} >{item.name}</option>
                                                    )
                                                })
                                            }
                                        </select>
                                    </div>
                                </div>
                                <div className="col-sm-6">
                                    <div className="form-group ">
                                        <label>Firma</label>
                                        <select
                                            onChange={itemHandler}
                                            className="form-control select2" style={{ width: "100%" }}>
                                           <option disabled defaultValue={0} >Seçiniz</option>
                                            {
                                                companies.map((item,index)=>{
                                                    return(
                                                        <option key={index} value={item.id} >{item.name}</option>
                                                    )
                                                })
                                            }
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div className="row">
                                <div className="col-6">
                                    <div className="form-group">
                                        <label htmlFor="exampleInputEmail1">Açıklama</label>
                                        <textarea
                                            name='description'
                                            className="form-control"
                                            value={item.description}
                                            onChange={itemHandler}
                                            placeholder="Açıklama"
                                        />
                                    </div>
                                </div>
                                <div className="col-6">
                                    <div className="form-group">
                                        <label htmlFor="exampleInputEmail1">Kurs bilgisi</label>
                                        <textarea
                                            name='experience'
                                            className="form-control"
                                            value={item.experience}
                                            onChange={itemHandler}
                                            placeholder="Kurs bilgisi"
                                        />
                                    </div>
                                </div>
                            </div>

                            <div className="row">
                                <div className="col-6">
                                    <div className="form-group">
                                        <label htmlFor="exampleInputEmail1">Adresi</label>
                                        <textarea
                                            name='address'
                                            className="form-control"
                                            value={item.address}
                                            onChange={itemHandler}
                                            placeholder="Kurs adresi"
                                        />
                                    </div>
                                </div>
                                <div className="col-6">
                                    <div className="form-group">
                                        <label htmlFor="exampleInputEmail1">İçeriği</label>
                                        <textarea
                                            name='content'
                                            className="form-control"
                                            value={item.content}
                                            onChange={itemHandler}
                                            placeholder="İçerik"
                                        />
                                    </div>
                                </div>
                            </div>


                            <div className="form-group">
                                <label htmlFor="exampleInputPassword1">Fiyat</label>
                                <input
                                    type="number"
                                    name='price'
                                    className="form-control"
                                    value={item.price}
                                    onChange={itemHandler}
                                    placeholder="Fiyat"
                                />
                            </div>
                            <div className="form-group">
                                <label htmlFor="exampleInputPassword1">Yorumlar</label>
                                <input
                                    type="text"
                                    name='comment'
                                    className="form-control"
                                    value={item.comment}
                                    onChange={itemHandler}
                                    placeholder="Yorumlar"
                                />
                            </div>
                            <div className="row">
                                <div className="col-6">
                                    <div className="form-group">
                                        <label htmlFor="exampleInputPassword1">Durum</label>
                                        <input
                                            type="text"
                                            name='status'
                                            className="form-control"
                                            placeholder="Durum"
                                            value={item.status}
                                            onChange={itemHandler}

                                        />
                                    </div>
                                </div>
                                <div className="col-6">
                                    <div className="form-check">
                                        <label className="form-check-label">Aftif</label>
                                        <input type="checkbox"
                                            name='isActive'
                                            onChange={itemHandler}
                                            value={item.status} className="form-control" />
                                    </div>
                                </div>
                            </div>



                        </div>
                        {/* /.card-body */}
                        <div className="card-footer">
                            <button type="button"
                            onClick={handleUpdate} className="btn btn-primary">
                                Kaydet
                            </button>
                        </div>
                    </form>
                }

            </div>
        </div>

    )
}



