pipeline {
   agent any
   
   stages {
      stage('Verify Branch') {
         steps{
            echo "$GIT_BRANCH"
         }
      }
      stage('Docker Build') {
         steps {
            powershell(script: 'docker-compose build')   
            powershell(script: 'docker images -a')
         }
      }
      stage('Run Application') {
         steps {
            powershell(script: 'docker-compose up -d')    
         }
      }
      stage('Stop Application') {
         steps {
            powershell(script: 'docker-compose down') 
            powershell(script: 'docker volume prune --force')   		
         }
      }
   }
}