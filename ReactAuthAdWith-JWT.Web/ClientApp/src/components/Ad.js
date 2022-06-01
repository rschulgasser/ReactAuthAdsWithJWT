import React from 'react';
import getAxios from '../AuthAxios';

const Ad = ({simpleAd, deleteMode,refreshAds}) => {
    const{ad, canDelete, userName}=simpleAd;
  const{phoneNumber,description,date,id}=ad;

    const  onDeleteClick =async (id) => {
        await getAxios().post('/api/ads/deletead',{id});
        
        refreshAds();
    }

    return <div className="mt-12 jumbotron">
    {userName&&<h5>Listed by {userName}</h5>}
    <h5>Listed on {date}</h5>
    <h5>Phone Number: {phoneNumber}</h5>
    <h3>Details:</h3>
    <p>{description}</p>
 
    {!!canDelete&&<button className="btn btn-danger" onClick={()=>onDeleteClick(id)}>Delete</button>}
</div>
}

export default Ad;