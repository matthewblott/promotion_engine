module.exports = (callback, inputs) => {
  let retVal = 0;

  let key1 = 'C';
  let key2 = 'D';

  let i = inputs.filter(x => x.key === key1 && x.key === key1).length;

  if(i > 0) {
    retVal = i * 5;
  }

 
  callback(null, retVal);
  
}