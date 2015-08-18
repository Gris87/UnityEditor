if [ -z "$1" ]; then
  echo "Usage: ./commit.sh MESSAGE"  
else
  git add .
  git commit -a -m "$1"

  git submodule foreach "git add ."
  git submodule foreach "git commit -a -m '$1'"

  . push.sh
fi
