// useTokenExpirationCheck.js
import { useEffect } from 'react';
import { useRouter } from 'next/navigation';

const useTokenExpirationCheck = () => {
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
        router.push('/login'); 
      }
    }
    else{
      router.push('/login'); 
    }
  }, [localStorage.getItem('access')]);

};

export default  useTokenExpirationCheck

