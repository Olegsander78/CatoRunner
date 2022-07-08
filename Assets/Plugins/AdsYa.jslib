mergeInto(LibraryManager.library, {
	

  BindWebGLTexture: function (texture) {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },

    ShowFullscreenAdv: function(){
    ysdk.adv.showFullscreenAdv({
          callbacks: {
          onClose: function(wasShown) {
            //myGameInstance.SendMessage('AdYAManager', 'ReturnTimeGame');
        },
          onError: function(error) {
            //myGameInstance.SendMessage('AdYAManager', 'ReturnTimeGame');
        }
      }
    })
  },

  ShowRewardedVideoForHP: function(){
    ysdk.adv.showRewardedVideo({
          callbacks: {
          onOpen: () => {
            console.log('Video ad for HP open.');
			//myGameInstance.SendMessage('AdYAManager', 'StopTimeGameForAd');
        },
          onRewarded: () => {
            console.log('Rewarded!');
            myGameInstance.SendMessage('AdYAManager', 'RewardAdForHP');
        },
          onClose: () => {
            console.log('Video ad for HP closed.');
			//myGameInstance.SendMessage('AdYAManager', 'ReturnTimeGame');
        }, 
          onError: (e) => {
            console.log('Error while open video ad HP:', e);
			//myGameInstance.SendMessage('AdYAManager', 'ReturnTimeGame');
        }
    }
    })
  },
  
  ShowRewardedVideoForScore: function(){
    ysdk.adv.showRewardedVideo({
          callbacks: {
          onOpen: () => {
            console.log('Video ad Score open.');
			//myGameInstance.SendMessage('AdYAManager', 'StopTimeGameForAd');
        },
          onRewarded: () => {
            console.log('Rewarded!');
            //myGameInstance.SendMessage('AdYAManager', 'RewardAdForScore');
        },
          onClose: () => {
            console.log('Video ad Score closed.');
			myGameInstance.SendMessage('AdYAManager', 'ReturnTimeGame');
        }, 
          onError: (e) => {
            console.log('Error while open video ad Score:', e);
			//myGameInstance.SendMessage('AdYAManager', 'ReturnTimeGame');
        }
    }
    })
  },


  TestLog: function(){
    console.log("TestLog");
  }


});