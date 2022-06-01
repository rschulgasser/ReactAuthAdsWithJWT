
import React, {useEffect, useState} from 'react';
import getAxios from '../AuthAxios';
import { useAuthContext } from '../AuthContext';
import Ad from '../components/Ad'


const Home = () => {
  const[ads, setAds]=useState([]);
  const { user } = useAuthContext();

  const getAds = async () => {

    const { data } = await getAxios().get('/api/ads/getallads');
  
    setAds(data);
   
}
useEffect(() => {
 

  getAds();
  console.log(ads); 
  
}, []);


 return <>
 <div className='col-md-6 offset-md-3'>
  {ads.map(b =>
   <Ad key={b.id}
          simpleAd={b}
          deleteMode={b.candelete}
          refreshAds={getAds}
    />)}
    </div>
  </>
}

export default Home;