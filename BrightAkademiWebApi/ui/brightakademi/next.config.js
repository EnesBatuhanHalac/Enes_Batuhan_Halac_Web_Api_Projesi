/** @type {import('next').NextConfig} */
const nextConfig = {
    images: {
      domains: ['avatars.githubusercontent.com', 'avatar.vercel.sh']
    },
    env:{
      API_URL: process.env.API_URL
    }
  };
  
  module.exports = nextConfig;