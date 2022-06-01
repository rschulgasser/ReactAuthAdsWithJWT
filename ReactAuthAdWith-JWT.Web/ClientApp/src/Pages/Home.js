
import React, {useEffect, useState} from 'react';
import getAxios from '../AuthAxios';
import { useAuthContext } from '../AuthContext';
import Ad from '../components/Ad'


const Home = () => {
  const[ads, setAds]=useState([]);
  const { user } = useAuthContext();

  const getAds = async () => {

    console.log('before'); 
    const { data } = await getAxios().get('/api/ads/getallads');
    console.log('after'); 
    const{ad}=data;
    setAds(ad);
   
}
useEffect(() => {
 

  getAds();
  
}, []);

const deleteMode=(id)=>{
  if(!user){
    return false;
  }
  console.log(id===user.id);
 return id===user.id;
}


 return <>
 <div className='col-md-6 offset-md-3'>
  {ads &&  ads.map(b =>
   <Ad key={b.id}
          ad={b}
          deleteMode={deleteMode(b.id)}
          refreshAds={getAds}
    />)}
    </div>
  </>
}

export default Home;