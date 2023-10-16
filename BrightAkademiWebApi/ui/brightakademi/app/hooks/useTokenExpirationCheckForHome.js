// useTokenExpirationCheck.js
import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
const  useTokenExpirationCheckForHome = () => {
  const router = useRouter();

  useEffect(() => {

    if (localStorage.getItem('access')) {
      const access = JSON.parse(localStorage.getItem('access'));
      const username = access?.username;
      const token = access?.token;
      const expireDate = access.expireDate;
      const currentTime = new Date();
      if (currentTime > new Date(expireDate)) {
        localStorage.removeItem('access');
      }
    }
    else{
    }
  }, [localStorage.getItem('access')]);

};


export default  useTokenExpirationCheckForHome
