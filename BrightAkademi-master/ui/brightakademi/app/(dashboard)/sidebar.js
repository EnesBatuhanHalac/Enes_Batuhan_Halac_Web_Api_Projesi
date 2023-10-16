"use client"
import Link from 'next/link';
import { useEffect, useState } from 'react';

export default function Sidebar() {
  const [activeMenu, setActiveMenu] = useState(null);
  const [userRoles, setUserRoles] = useState([]);

  const handleMenuClick = (index) => {
    setActiveMenu(index);
  };

  useEffect(() => {
    if (localStorage.getItem('access')) {
    const roles =JSON.parse(localStorage.getItem('access')).roles;
    setUserRoles(roles);
    }
  }, []);

  const menuItems = [
    { path: '/', text: 'Dashboard', icon: 'fas fa-home', roles: ['Super Admin', 'Admin','Trainer', 'Trainee']},
    { path: '/companies', text: 'Şirketler', icon: 'far fa-building', roles:['Super Admin', 'Admin','Trainer', 'Trainee'] },
    { path: '/mycourses', text: 'Derslerim', icon: 'fas fa-book-open', roles: ['Trainee'] },
    { path: '/courses', text: 'Dersler', icon: 'fas fa-book-open', roles: ['Super Admin', 'Admin','Trainer', 'Trainee'] },
    { path: '/students', text: 'Öğrenciler', icon: 'fas fa-user-graduate',roles: ['Super Admin', 'Admin','Trainer'] },
    { path: '/teachercourses', text: 'Derslerim', icon: 'fas fa-book-open',roles: ['Trainer'] },
    { path: '/teachers', text: 'Öğretmenler', icon: 'fas fa-chalkboard-teacher', roles:['Super Admin', 'Admin','Trainer', 'Trainee'] },
    { path: '/categories', text: 'Kategoriler', icon: 'fas fa-shapes', roles:['Super Admin', 'Admin'] },
    { path: '/levels', text: 'Seviyeler', icon: 'fas fa-align-right', roles:['Super Admin'] },
    { path: '/users', text: 'Kullanıcılar', icon: 'fas fa-users', roles:['Super Admin'] },
    { path: '/roles', text: 'Roller', icon: 'fas fa-user-tag', roles:['Super Admin'] },
  ];

  return (
    <nav className="mt-2">
      <ul
        className="nav nav-pills nav-sidebar flex-column"
        data-widget="treeview"
        role="menu"
        data-accordion="false"
      >
        {menuItems.map((item, index) => (
          userRoles.some(role => item.roles.includes(role)) && (
            <li className="nav-item" key={index}>
              <Link href={item.path}
                  className={`nav-link ${index === activeMenu ? 'active' : ''}`}
                  onClick={() => handleMenuClick(index)}
                >
                  <i className={`nav-icon ${item.icon}`}></i>
                  <p>
                    {item.text}
                  </p>
              </Link>
            </li>
          )
        ))}
      </ul>
    </nav>
  );
}
