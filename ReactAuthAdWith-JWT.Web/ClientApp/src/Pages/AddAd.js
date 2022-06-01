import React, {useState, useEffect} from 'react';
import getAxios from '../AuthAxios';
import { useAuthContext } from '../AuthContext';
import { useHistory } from 'react-router-dom';

const AddAd = () => {
    const [phoneNumber, setPhoneNumber] = useState();
    const [description, setDescription] = useState();
    const { user } = useAuthContext();
    const history = useHistory();

    const onFormSubmit =async(e)=> {
    
            e.preventDefault();
            await getAxios().post('/api/ads/addad', {phoneNumber, description});
            history.push('/');
        
      
    }

    return (
        <div className="row">
            <div className="col-md-6 offset-md-3 card card-body bg-light">
                <h3>New Ad</h3>
              
                <form onSubmit={onFormSubmit}>
                    <input onChange={(e)=>setPhoneNumber(e.target.value)} value={phoneNumber} type="text" name="phoneNumber" placeholder="Phone Number" className="form-control" />
                    <br />
                    <textarea onChange={(e)=>setDescription(e.target.value)} name="description" className="form-control" rows="10" placeholder="Description" value={description}></textarea>
                    <br />
                    <button className="btn btn-primary">Submit</button>
                </form>
              
            </div>
        </div>
    )
}

export default AddAd;