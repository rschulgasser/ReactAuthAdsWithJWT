import React, {useEffect, useState} from 'react';
import getAxios from '../AuthAxios';
import Axios from 'axios';
import { useAuthContext } from '../AuthContext';
import Ad from '../components/Ad'


const MyAccount = () => {
  const[ads, setAds]=useState([]);
const { User } = useAuthContext();

const getAds = async () => {
    const { data } = await getAxios().get('/api/ads/getadsforuser');
    setAds(data);
  console.log(data); 
}
useEffect(() => {


  getAds();
  
}, []);


 return <>
 <div className='col-md-6 offset-md-3'>
  {ads &&  ads.map(b =>
   <Ad key={b.id}
          simpleAd={b}
          
          refreshAds={getAds}
    />)}
    </div>
  </>
}

export default MyAccount;