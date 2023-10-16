// useTokenExpirationCheck.js

const hasAccess = () => {

    if (localStorage.getItem('access')) {
        const access = JSON.parse(localStorage.getItem('access'));
        const roles =access.roles;
        if(roles.includes("Super Admin") || roles.includes("Super Admin")){
            return true;
        }else{
            return false;
        }
    }
    return false;
};

export default hasAccess;
